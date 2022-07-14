using StackExchange.Redis;
using System;

namespace RedisTest_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            if (args != null && args.Length > 0)
            {
                var operation = args[0].ToString();
                switch(operation.ToLower())
                {
                    case "insertcache":
                    case "testcache":
                        TestRedisCache();
                        break;

                    case "getcache":

                        break;

                    default:

                        break;
                }
            }
            else
            {
                Console.WriteLine("Please provide necessary arguments when running the program!");
            }
        }

        public static void TestRedisCache(string key = null, string val = null)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            // ^^^ store and re-use this!!!

            IDatabase db = redis.GetDatabase();
            key = "testkey:123";
            val = "test value 456";
            db.StringSet("mykey", val);

            db.StringSetAsync(key, val);

            //db.StringSetAsync(key, val, null, false, When.Always, CommandFlags.None);
            Console.WriteLine("value is set in Redis to: " + val); // writes: "abcdefg"



            Console.WriteLine("Start - Get Value from Redis for Key: " + key); // writes: "abcdefg"

            val = db.StringGet(key);
            Console.WriteLine("Value is set in Redis for key: '" + key + "' is: " + val); // writes: "abcdefg"

            Console.WriteLine("End - Get Value from Redis for Key: " + key); // writes: "abcdefg"
        }

    }



}
