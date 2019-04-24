using System;
using static System.Console;
using static System.Convert;

namespace unit6
{
    class Program
    {
        delegate double delegatepross(double param1,double param2);
        public static double sum(double param1,double param2)=>param1+param2;
        public static void add(ref double param1,double param2){
            param1 +=param2;
        }
        public static void add1(double param1,double param2,out double outnum){
            outnum = param1 + param2; 
        }
        public static double add2(params double[] darray){
            double sum = 0d;
            foreach(double d in darray)
            sum+=d;
            return sum;
        }
        static void Main(string[] args)
        {
            delegatepross pross = new delegatepross(sum);
            WriteLine("input number:");
            string input = ReadLine();
            int index = input.IndexOf(",");
            double d1 = ToDouble(input.Substring(0,index));
            double d2 = ToDouble(input.Substring(index+1,input.Length-index-1));
            add(ref d1,d2);
            WriteLine($"add, d1 = {d1}, d2 = {d2}");
            add1(d1,d2,out double outnum);
            WriteLine($"add1, d1 = {d1}, d2 = {d2}, sum ={outnum}");
            WriteLine($"add2, sum = {add2(d1,d2,outnum)}");
            WriteLine($"pross, sum = {pross(d1,d2)}");
        }
    }
}
