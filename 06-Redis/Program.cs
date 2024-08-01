namespace _06_Redis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //连接
            var constr = $"127.0.0.1:6379,ssl=false,writeBuffer=10240,prefix=fz";
            var csredis = new CSRedis.CSRedisClient(constr);
            RedisHelper.Initialization(csredis);
            RedisHelper.Set("name", "xujinbin");
            var name = RedisHelper.Get("name");

            Console.ReadKey();
        }
    }
}
