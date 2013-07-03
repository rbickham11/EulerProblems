using System;
using System.Diagnostics;
using System.IO;
using System.Collections;
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
            problem23();
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
                    {
                        Console.WriteLine(n1 + " " + n2);
                        amSum += (n1 + n2);
                    }
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
            if (Math.Sqrt(n) % 1 == 0 && n != 1)
                divSum += (int)Math.Sqrt(n);
               
           return divSum;
        }

        public void problem22() //What is the total of all the name scores in the file? 
        {                       //Name score = (Sum of letters by alphabet position) * (Position in alphabetically sorted list of names)
            stopWatch.Restart();

            List<string> names;
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int alphaVal, i;
            int total = 0;

            Console.Write("Problem 22: ");

            using (StreamReader sr = new StreamReader("names.txt"))
                names = new List<string>(sr.ReadToEnd().Replace("\"", "").Split(','));

            names.Sort();
            foreach (string name in names)
            {
                alphaVal = 0;
                for (i = 0; i < name.Length; i++)
                    alphaVal += Array.IndexOf(alphabet, name[i]) + 1;
                total += alphaVal * (names.IndexOf(name) + 1);
            }

            Console.Write(total);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem23() //Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
        {
            stopWatch.Restart();

            limit = 28123;
            List<int> abNums = new List<int>();
            int i, j;
            int sum = 0;
            BitArray isSum = new BitArray((int)limit + 1);

            Console.Write("Problem 23: ");

            for (i = 1; i < limit; i++)
                if (sumDivisors(i) > i)
                    abNums.Add(i);

            foreach (int abNum1 in abNums)
            {
                for (i = abNums.IndexOf(abNum1); i < abNums.Count; i++)
                {
                    if (abNum1 + abNums[i] <= limit)
                        isSum[abNum1 + abNums[i]] = true;
                    else
                        break;
                }
            }

            for (i = 0; i < isSum.Length; i++)
                if (!isSum[i])
                    sum += i;

            Console.Write(sum);
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
