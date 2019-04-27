using System;
using static System.Console;
using static System.Convert;
using static System.Array;

namespace sort1
{

    class Program
    {
        static void sort(ref int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = i; j < array.Length; ++j)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            WriteLine("input:");
            string input = ReadLine();
            string[] sarray = input.Split(",");
            int[] array = ConvertAll<string, int>(sarray, int.Parse);
            sort(ref array);
            foreach (int i in array)
                WriteLine(i);
        }
    }
}
