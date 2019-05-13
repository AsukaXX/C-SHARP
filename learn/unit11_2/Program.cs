using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit11_2
{
    public class Prims
    {
        private long min;
        private long max;
        public Prims() : this(2, 100) { }
        public Prims(long minnum, long maxnum)
        {
            if (minnum < 2)
            {
                min = 2;
            }
            else
            {
                min = minnum;
            }
            max = maxnum;
        }
        public IEnumerator GetEnumerator()
        {
            for (long possiblePrime = min; possiblePrime <= max; possiblePrime++)
            {
                bool isProme = true;
                for (long possibleFactor = 2; possibleFactor <= (long)Math.Floor(Math.Sqrt(possiblePrime)); possibleFactor++)
                {
                    long remainderAfterDivision = possiblePrime % possibleFactor;
                    if (remainderAfterDivision == 0)
                    {
                        isProme = false;
                        break;
                    }
                }
                if (isProme)
                {
                    yield return possiblePrime;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Prims primsDrom2To1000 = new Prims(2, 1000);
            foreach (long i in primsDrom2To1000)
                Console.Write($"{i} ");
        }
    }
}
