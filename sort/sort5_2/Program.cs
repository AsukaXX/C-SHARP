using System;

namespace sort5_2
{

    class Program
    {
        static void sort(ref int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; i += i)
            {
                int left = 0;
                int mid = left + i - 1;
                int right = mid + i;
                while (right < n)
                {
                    merge(ref array, left, mid, right);
                    left = right + 1;
                    mid = left + i - 1;
                    right = mid + i;
                }
                if (left < n && mid < n)
                {
                    merge(ref array, left, mid, n - 1);
                }
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
            String input = Console.ReadLine();
            int[] array = Array.ConvertAll<String, int>(input.Split(","), int.Parse);
            sort(ref array);
            foreach (int t in array)
            {
                Console.Write(t + " ");
            }
        }
    }
}
