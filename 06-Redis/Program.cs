namespace _06_Redis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //连接
            var constr = $"127.0.0.1:6379,ssl=false,writeBuffer=10240,prefix=fz_";
            var csredis = new CSRedis.CSRedisClient(constr);
            RedisHelper.Initialization(csredis);

            //5种常见数据类型
            //1、字符串
            RedisHelper.Set("name", "xujinbin");
            var name = RedisHelper.Get("name");
            Console.WriteLine($"字符串name={name}");

            //2、List列表
            RedisHelper.LPush("shopping_list", "面包");
            RedisHelper.LPush("shopping_list", "大米");
            RedisHelper.LPush("shopping_list", "牛肉");
            var last_shops = RedisHelper.RPop("shopping_list");
            Console.WriteLine($"List列表最后一个值={last_shops}");

            //3、Hash字典
            RedisHelper.HSet("student_list", "1", "熊大");
            RedisHelper.HSet("student_list", "2", "王二");
            RedisHelper.HSet("student_list", "3", "张三");
            RedisHelper.HSet("student_list", "4", "李四");
            var id_4_name = RedisHelper.HGet("student_list", "4");
            Console.WriteLine($"Hash字典Filed=4的值：{id_4_name}");

            //4、Set集合，无序的
            RedisHelper.SAdd("id_lang", ".net", "java", "python", "go");
            var set_length = RedisHelper.SCard("id_lang");
            Console.WriteLine($"Set集合id_lang长度：{set_length}");
            var is_exist = RedisHelper.SIsMember("id_lang", "python");
            Console.WriteLine($"Set集合id_lang有python值：{is_exist}");

            //5、Zset有序集合
            RedisHelper.ZAdd("zset_name", (5, "王五"));
            RedisHelper.ZAdd("zset_name", (3, "张三"), (4, "李四"));
            var set_lst = RedisHelper.ZRange("zset_name", 0, -1);
            foreach (var item in set_lst)
            {
                //默认按照score从小到大输出
                Console.WriteLine($"zset item = {item}");
            }

            Console.WriteLine("\r\n\r\n========================================");

            //BLPop阻塞式读取，当redis队列没有数据时，自动阻塞，直到新的数据写入
            while (true) 
            {
                try
                {
                    var s = RedisHelper.BLPop(100, "aaa");
                    if (!string.IsNullOrEmpty(s))
                    {
                        continue;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
