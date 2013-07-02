using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace EulerProblems
{
    class EulerProblems21_30
    {
        private long limit;
        private Stopwatch stopWatch = new Stopwatch();

        public void runAll()
        {
            problem21();
            problem22();
        }

        public void problem21() //Evaluate the sum of all the amicable numbers under 10000.
        {
            stopWatch.Restart();

            limit = 10000;
            int n1, n2, n1Sum, n2Sum;
            int amSum = 0;

            Console.Write("Problem 21: ");

            for (n1 = 0; n1 < limit; n1++)
            {
                n1Sum = sumDivisors(n1);
                n2 = n1Sum;
                if (n1 < n2)
                {
                    n2Sum = sumDivisors(n2);
                    if (n2Sum == n1)
                        amSum += (n1 + n2);
                }
            }

            Console.Write(amSum);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public int sumDivisors(int n)
        {
            int divSum = 1;

            for(int i = 2; i < Math.Sqrt(n); i++)
                if (n % i == 0)
                    divSum += (i + (n / i));
               
           return divSum;
        }

        public void problem22()
        {
            stopWatch.Restart();

            List<string> names;
            Console.Write("Problem 22: ");

            using (StreamReader sr = new StreamReader("names.txt"))
                names = new List<string>(sr.ReadToEnd().Replace("\"", "").Split(','));
            

            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem()
        {
            stopWatch.Restart();

            Console.Write("Problem: ");

            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }
    }
}
