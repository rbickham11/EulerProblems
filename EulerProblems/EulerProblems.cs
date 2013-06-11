using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EulerProblems
{
    class EulerProblems
    {
        private int i;
        private int sum;
        private long limit;
        private Stopwatch stopWatch;

        static void Main(string[] args)
        {
            EulerProblems euler = new EulerProblems();
            euler.stopWatch = new Stopwatch();

            euler.problem1();
            euler.problem2();
            euler.problem3();
            euler.problem4();
            euler.problem5();
            Console.ReadKey();
        }
        public void problem1()  //Find the sum of all the multiples of 3 or 5 below 1000.
        {
            stopWatch.Restart();
            limit = 1000;
            int sum = 0;

            Console.Write("Problem 1: ");

            for (i = 0; i < limit; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))
                    sum = sum + i;           
            }
            Console.Write(sum);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }
        public void problem2() //By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
        {
            stopWatch.Restart();
            limit = 4000000;
         

            int lastTerm = 1;
            int curTerm = 2;
            int tempTerm;

            Console.Write("Problem 2: ");
            while (curTerm <= limit)
            {
                if (curTerm % 2 == 0)
                    sum += curTerm;

                tempTerm = lastTerm + curTerm;
                lastTerm = curTerm;
                curTerm = tempTerm;
            }

            Console.Write(sum);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }
        public void problem3() //What is the largest prime factor of the number 600851475143 ?
        {
            stopWatch.Restart();
            limit = 600851475143;
          

            Console.Write("Problem 3: ");

            int max = 1;
            List<long> PrimeFactors = new List<long>();
            int loopMax = (int)Math.Sqrt(limit) + 10;

            BitArray bitArr = new BitArray(loopMax);
            bitArr.Set(2, false);
                
            if (limit % 2 == 0)
            {
                limit /= 2;
                PrimeFactors.Add(2);
            }

            for (int i = 3; i < loopMax; i += 2)
            {
                if (!bitArr.Get(i))
                {
                    while (true)
                    {
                        if (limit % i == 0)
                        {
                            limit /= i;
                            PrimeFactors.Add(i);
                            max = i;
                        }
                        else break;
                    }
                }
                if (limit == 1) break;
                for (int j = 2 * i; j < loopMax; j += i)
                    bitArr.Set(j, true);
            }

            Console.Write(max);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem4() //Find the largest palindrome made from the product of two 3-digit numbers.
        {
            stopWatch.Restart();

            const int MAX_MULTIPLE = 999;
            const int MIN_MULTIPLE = 100;
            int intResult, i, j;
            string stringResult;
            bool breakBoth = false;
            int max = 0;
            
            Console.Write("Problem 4: ");
           
            for (int first = MAX_MULTIPLE; first > MIN_MULTIPLE; first--)
            {
                breakBoth = false;
                if (max > first * MAX_MULTIPLE)
                    break;

                for (int second = first; second > MIN_MULTIPLE; second--)
                {
                    intResult = first * second;
                    stringResult = intResult.ToString();
                    i = 0;
                    j = stringResult.Length - 1;

                    while ((i < j) && (stringResult[i] == stringResult[j]))
                    {
                        if (j == i + 1 || j == i + 2)
                        {
                            if (intResult > max)
                                max = intResult;
                            
                            breakBoth = true;
                            break;
                        }

                        i++;
                        j--;
                    }
                    if (breakBoth) break;
                }
            }

            if (max == 0)
                Console.Write("No palindromes found");
            else
                Console.Write(max);

            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem5()  //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        {
            stopWatch.Restart();

            Console.Write("Problem 5: ");
            int maxMultiple = 20;
            int num = maxMultiple * 2;

            List<int> multiples = new List<int>();
            
            for(int i = 0; i <= maxMultiple; i++)
                multiples.Add(i);

            for (int i = maxMultiple; i > maxMultiple / 2; i--)
            {
                for (int j = 2; j <= i / 2; j++)
                    if (i % j == 0)
                        multiples.Remove(j);
            }
            multiples.Remove(0);
            multiples.Remove(1);

            while (true)
            {
                while (i < multiples.Count)
                {
                    if (num % multiples[i] != 0)
                        break;
                    i++;
                }
                if (i == multiples.Count)
                    break;
                i = 0;
                num++;
            }

            Console.Write(num);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem()  
        {
            stopWatch.Restart();
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

    }
}
