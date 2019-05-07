using System;

namespace sort5
{
    class Program
    {
        static void sort(ref int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                sort(ref array, left, mid);
                sort(ref array, mid + 1, right);//注意mid要加一，不然会死循环
                merge(ref array, left, mid, right);
            }
        }
        static void merge(ref int[] array, int left, int mid, int right)
        {
            int[] arr = new int[right - left + 1];
            int i = left;
            int j = mid + 1;
            int k = 0;
            while (i <= mid && j <= right)
            {
                if (array[i] < array[j])
                {
                    arr[k++] = array[i++];
                }
                else
                {
                    arr[k++] = array[j++];
                }
            }
            while (i <= mid) arr[k++] = array[i++];
            while (j <= right) arr[k++] = array[j++];
            foreach (int t in arr)
            {
                array[left++] = t;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("input:");
            string input = Console.ReadLine();
            int[] array = Array.ConvertAll<string, int>(input.Split(","), int.Parse);
            sort(ref array, 0, array.Length - 1);
            foreach (int t in array)
            {
                Console.Write(t + " ");
            }
        }
    }
}
