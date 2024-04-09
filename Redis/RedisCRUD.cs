using StackExchange.Redis;
using System;

namespace Redis
{
    public class RedisCRUD
    {
        private ConnectionMultiplexer _redis;
        string _connectionString;

        public RedisCRUD(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Save(string Id, string serializedObject)
        {
            bool result;
            try//try to connect from local machine
            {
                _redis = ConnectionMultiplexer.Connect(_connectionString+",connectTimeout=10000,responseTimeout=10000");//localhost
            }
            catch (Exception)//connect to docker
            {
                _redis = ConnectionMultiplexer.Connect("redis:6379,connectTimeout=10000,responseTimeout=10000");//redis is name container
            }

            var db = _redis.GetDatabase();
            result = db.StringSet(Id, serializedObject);

            _redis.Close();

            return result;
        }
        public string Get(string Id)
        {
            string result = "";
            try//try to connect from local machine
            {
                _redis = ConnectionMultiplexer.Connect(_connectionString + ",connectTimeout=10000,responseTimeout=10000");//localhost
            }
            catch (Exception)//connect to docker
            {
                _redis = ConnectionMultiplexer.Connect("redis:6379,connectTimeout=10000,responseTimeout=10000");//redis is name container
            }

            var db = _redis.GetDatabase();
            result = db.StringGet(Id);
            _redis.Close();

            return result;
        }
        public bool Delete(string Id)
        {
            try//try to connect from local machine
            {
                _redis = ConnectionMultiplexer.Connect(_connectionString + ",connectTimeout=10000,responseTimeout=10000");//localhost
            }
            catch (Exception)//connect to docker
            {
                _redis = ConnectionMultiplexer.Connect("redis:6379,connectTimeout=10000,responseTimeout=10000");//redis is name container
            }

            var db = _redis.GetDatabase();
            bool result = db.KeyDelete(Id);
            _redis.Close();
            return result;
        }
    }
}
