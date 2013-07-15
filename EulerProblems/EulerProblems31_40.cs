using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace EulerProblems
{
    class EulerProblems31_40
    {
        private long limit;
        private Stopwatch stopWatch = new Stopwatch();

        public void runAll()
        {
            problem31();
            problem32();
            problem33();
            //problem34();
            //problem35();
            //problem36();
            //problem37();
            //problem38();
            //problem39();
            //problem40();
        }

        public void problem31() //How many different ways can £2 be made using any number of coins?
        {
            stopWatch.Restart();
            limit = 200;
            int i, j;
            int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };
            int[] ways = new int[limit + 1];
            ways[0] = 1;

            Console.Write("Problem 31: ");
            for (i = 0; i < coins.Length; i++)
                for (j = coins[i]; j <= limit; j++)
                    ways[j] += ways[j - coins[i]];

            Console.Write(ways[limit]);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem32() //Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
        {
            stopWatch.Restart();
            int i, j;
            string numbers;
            int sum = 0;
            List<int> products = new List<int>();

            Console.Write("Problem 32: ");
            for (i = 1; i < 10; i++)
            {
                for (j = 1234; j < 9876; j++)
                {
                    numbers = i.ToString() + j.ToString() + (i * j).ToString();
                    if (isPandigital(Convert.ToInt64(numbers)))
                    {
                        if (!products.Contains(i * j))
                        {
                            products.Add(i * j);
                            sum += (i * j);
                        }
                    }
                }
            }

            for (i = 12; i < 98; i++)
            {
                for (j = 123; j < 987; j++)
                {
                    numbers = i.ToString() + j.ToString() + (i * j).ToString();
                    if (isPandigital(Convert.ToInt64(numbers)))
                    {
                        if (!products.Contains(i * j))
                        {
                            products.Add(i * j);
                            sum += (i * j);
                        }
                    }
                }
            }
            Console.Write(sum);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public bool isPandigital(long n)
        {
            int digits = 0;
            int count = 0;
            int temp;

            while (n > 0)
            {
                temp = digits;
                digits = digits | 1 << (int)(n % 10 - 1);
                if (temp == digits)
                    return false;

                count++;
                n /= 10;
            }
            return digits == (1 << count) - 1;
        }

        public void problem33()
        {
            stopWatch.Restart();
            int i, j;
            double fraction, newFraction;
            int numProduct = 1;
            int denProduct = 1;

            Console.Write("Problem 33: ");

            for (i = 11; i < 100; i++)
            {
                if ((i % 10 == 0) || ((i % 10) == (i / 10)))
                    continue;

                for (j = i % 10 * 10; j < i % 10 * 10 + 11; j++)
                {
                    fraction = (double)i / j;
                    newFraction = (double)(i / 10) / (j % 10);
                    if (fraction == newFraction)
                    {
                        numProduct *= i;
                        denProduct *= j;
                    }
                }
            }

            Console.Write(denProduct / EuclidGCD(numProduct, denProduct));
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public int EuclidGCD(int n, int m)
        {
            int temp;
            if (n < m)
            {
                temp = n;
                n = m;
                m = temp;
            }
            while (n % m != 0)
            {
                temp = n;
                n = m;
                m = temp % n;
            }
            return m;
        }

        public void problem()
        {
            stopWatch.Restart();
            Console.Write("Problem : ");
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

    }
}
