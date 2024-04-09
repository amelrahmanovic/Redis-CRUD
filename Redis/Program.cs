using Newtonsoft.Json;
using System;

namespace Redis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RedisCRUD redisCRUD = new RedisCRUD("localhost");

            int opcija = 1;
            do
            {
                bool succesInput;
                do
                {
                    try
                    {
                        Console.WriteLine("0-Add:");
                        Console.WriteLine("1-Read");
                        Console.WriteLine("2-Delete:");
                        Console.WriteLine("3-Key exist:");
                        Console.WriteLine("10-EXIT:");
                        Console.WriteLine("Option:");
                        opcija = int.Parse(Console.ReadLine());
                        Console.Clear();
                        succesInput = true;
                    }
                    catch (Exception)
                    {
                        succesInput = false;
                        Console.Clear();
                        Console.WriteLine("This is not number...");
                    }
                } while (!succesInput);


                switch (opcija)
                {
                    case 0:
                        Console.WriteLine("Added: " + redisCRUD.Save("Test", "test"));
                        break;
                    case 1:
                        var json = redisCRUD.Get("Test");
                        Console.WriteLine("Result: "+json);
                        break;
                    case 2:
                        Console.WriteLine("Delete: " + redisCRUD.Delete("Test"));
                        break;
                    case 3:
                        Console.WriteLine("Key exist: " + redisCRUD.ExistKey("Test"));
                        break;

                    case 10: Environment.Exit(0); break;
                    default: break;
                }
            } while (true);
        }
    }
}
