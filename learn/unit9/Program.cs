using System;

namespace unit9
{
    public abstract class MyBase{}
    internal class MyClass:MyBase{}
    public interface IMyBaseInterface{}
    internal interface IMyBaseInterface2{}
    internal interface IMyInterface:IMyBaseInterface,IMyBaseInterface2{}
    internal sealed class MyComplexClass:MyClass,IMyInterface{}
    class Program
    {
        static void Main(string[] args)
        {
            MyComplexClass myobj = new MyComplexClass();
            Console.WriteLine(myobj.ToString());
        }
    }
}
