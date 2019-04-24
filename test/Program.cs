using System;

namespace test
{
    class Program
    {
        static void add(out int i,ref int k){
            int j = 3;
            i = j;
            k+=3;

        }

        static (int max,int min,double avg) avge(params int[] array){
            int sum = 0;
            int max = array[0];
            int min = array[0];
            foreach(int i in array){
                if(i>max)
                max = i;
                if(i<min)
                min = i;
                sum += i;
            }
            double avg = sum/array.Length;
            return (max,min,avg);
        }
        static void Main(string[] args)
        {
            int i;
            int k = 0;
            add(out i ,ref k);
            (int max,int min,double avg ) = avge(1,2,3,4,5,6);
            Console.WriteLine($"value of i = {i}\nvalue of k = {k}");
            Console.Write($"max = {max}\nmin = {min}\navg = {avg}");
        }
    }
}
