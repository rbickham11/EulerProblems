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
            problem24();
            problem25();
            problem26();
            //problem27();
            //problem28();
            //problem29();
            //problem30();
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
            int i;
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

        public void problem24() //What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
        {
            stopWatch.Restart();

            limit = 1000000;
            List<int> nums = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int i;
            int maxP = factorial(10);
            int currentP = 0;
            int digitCount = 0;

            Console.Write("Problem 24: ");

            for(i = 10; i >= 1; i--)
            {
                maxP /= i;
                while (currentP < limit)
                {
                    currentP += maxP;
                    digitCount++;
                }

                currentP -= maxP;
                
                Console.Write(nums[digitCount - 1]);
                nums.RemoveAt(digitCount - 1);
                digitCount = 0;
            }
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public int factorial(int n)
        {
            if (n < 1)
                return 1;
            else
                return n * factorial(n - 1);
        }

        public void problem25() //What is the first term in the Fibonacci sequence to contain 1000 digits?
        {
            stopWatch.Restart();

            Console.Write("Problem 25: ");

            Console.Write(Math.Ceiling((Math.Log(10) * 999 + (Math.Log(5) / 2)) / Math.Log((1 + Math.Sqrt(5)) / 2)));
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem26() //Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
        {
            stopWatch.Restart();
            limit = 1000;
            int i, thisCycle, remainder;
            int longCycle = 0;
            int maxCycle = 0;
            BitArray remainders;

            Console.Write("Problem 26: ");
            for (i = (int)limit - 1; i > 1; i--)
            {
                if (longCycle > i)
                    break;
                remainders = new BitArray(i);
                thisCycle = 0;
                remainder = 1;
                while (remainders[remainder] == false && remainder != 0)
                {
                    remainders[remainder] = true;
                    remainder = (remainder * 10) % i;
                    thisCycle++;
                }

                if (thisCycle > longCycle)
                {
                    longCycle = thisCycle;
                    maxCycle = i;
                }
            }
            Console.Write(maxCycle);
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
