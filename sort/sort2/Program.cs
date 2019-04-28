using System;
using static System.Console;
using static System.Array;

namespace sort2
{
    class Program
    {
        static void sort(ref int[] array){
            for(int i = 1;i<array.Length;++i){
                for(int j =i-1;j>=0;--j){
                    if(array[j]<=array[i]){
                        int temp = array[i];
                        for(int k =i-1;k>j;--k){
                            array[k+1] =array[k];
                        }
                        array[j+1] =temp;
                        break;
                    }
                    if(j==0){
                        int temp = array[i];
                        for(int k =i-1;k>=0;--k){
                            array[k+1] =array[k];
                        }
                        array[0] =temp;
                    }
                }
            }
        }
        static void sort1(ref int[] array){
            for(int i = 1;i<array.Length;++i){
                    int temp = array[i];
                    int k = i-1;
                    while(k>=0&&array[k]>temp)
                        --k;
                    for(int j = i-1;j>k;--j){
                        array[j+1] = array[j];
                    }
                    array[k+1] = temp;
            }
        }
        static void Main(string[] args)
        {
            WriteLine("input:");
            string input = ReadLine();
            int[] array = ConvertAll<string,int>(input.Split(","),int.Parse);
            sort1(ref array);
            foreach(int t in array)
                Write(t+" ");
        }
    }
}
