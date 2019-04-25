using System;
using static System.Console;
using static System.Convert;
namespace test
{
    class Program
    {
        public static Boolean isOdd(int i)
        {
            if (i % 2 == 1)
                return true;
            else
                return false;
        }
        public static Boolean isOdd1(int i)
        {
            return (i % 2 == 1 || i % 2 == -1);
        }
        public static Boolean isOdd2(int i)
        {
            return (i % 2 != 0);
        }
        public static Boolean isOdd3(int i)
        {
            return (i >> 1 << 1 != i);
        }
        public static Boolean isOdd4(int i)
        {
            return (i & 1) == 1;
        }
        static void Main(string[] args)
        {
            WriteLine("input:");
            string s = ReadLine();
            int i = ToInt32(s);
            WriteLine($"{isOdd4(i)}");
        }
    }
}
