using System;
using static System.Console;
using static System.Array;

namespace sort3
{
    class Program
    {
        static void sort(ref int[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            WriteLine("input");
            string input = ReadLine();
            int[] array = ConvertAll<string, int>(input.Split(","), int.Parse);
            sort(ref array);
            foreach (int t in array)
                Write(t + " ");
        }
    }
}
