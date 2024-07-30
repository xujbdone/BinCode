namespace _05_ObjectOriented
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1、虚方法
            VirtualMethod.SayHi();

            //public无限制 internal当前项目 private类内部 
            //protected 继承该类的可访问，类中方法默认次修饰符
            //Abstract 表示该类不能被实例化，只能被继承
            //Sealed   表示该类只能被实例化，不能被继承

            //2、抽象类
            Abstract.Run();


            Console.ReadKey();
        }
    }
}