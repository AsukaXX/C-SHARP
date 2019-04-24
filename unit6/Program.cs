using System;
using static System.Console;
using static System.Convert;

namespace unit6
{
    class Program
    {
        delegate double delegatepross(double param1,double param2);
        public static double sum(double param1,double param2)=>param1+param2;
        static void Main(string[] args)
        {
            delegatepross pross = new delegatepross(sum);
            WriteLine("input number:");
            string input = ReadLine();
            int index = input.IndexOf(",");
            double d1 = ToDouble(input.Substring(0,index));
            double d2 = ToDouble(input.Substring(index+1,input.Length-index-1));
            WriteLine($"sum = {pross(d1,d2)}");
            ReadKey();
        }
    }
}
