using System;
using static System.Array;
using static System.Console;

namespace sort4
{
    class Program
    {
        static void sort(ref int[] array)
        {
            int n = array.Length;
            for (int h = n / 2; h > 0; h /= 2)
            {
                for (int i = h; i < n; i++)
                {
                    insert(ref array, h, i);
                }
            }
        }
        static void insert(ref int[] array, int h, int i)
        {
            int temp = array[i];
            int k;
            for (k = i - h; k >= 0 && temp < array[k]; k -= h)
            {
                array[k + h] = array[k];
            }
            array[k + h] = temp;
        }
        static void Main(string[] args)
        {
            WriteLine("input:");
            string input = ReadLine();
            int[] array = ConvertAll<string, int>(input.Split(","), int.Parse);
            sort(ref array);
            foreach (int t in array)
            {
                Write($"{t} ");
            }
        }
    }
}
