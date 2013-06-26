using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EulerProblems1_10
{
    class EulerProblems1_10
    {
        private long sum;
        private long limit;
        private Stopwatch stopWatch;

        static void Main(string[] args)
        {
            EulerProblems1_10 euler = new EulerProblems1_10();
            euler.stopWatch = new Stopwatch();

            euler.problem1();
            euler.problem2();
            euler.problem3();
            euler.problem4();
            euler.problem5();
            euler.problem6();
            euler.problem7();
            euler.problem8();
            euler.problem9(); 
            euler.problem10();


            Console.ReadKey();
        }
        public void problem1()  //Find the sum of all the multiples of 3 or 5 below 1000.
        {
            stopWatch.Restart();
            limit = 1000;
            int sum = 0;

            Console.Write("Problem 1: ");

            for (int i = 0; i < limit; i++)
                if ((i % 3 == 0) || (i % 5 == 0))
                    sum += i;           
           
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
            int i;
            int maxMultiple = 20;
            int num = maxMultiple * 2;

            List<int> multiples = new List<int>();

            Console.Write("Problem 5: ");

            for(i = 0; i <= maxMultiple; i++)
                multiples.Add(i);

            for (i = maxMultiple; i > maxMultiple / 2; i--)
            {
                for (int j = 2; j <= i / 2; j++)
                    if (i % j == 0)
                        multiples.Remove(j);
            }
            multiples.Remove(0);
            multiples.Remove(1);
            
            while (true)
            {
                for (i = 0; i < multiples.Count; i++)
                    if (num % multiples[i] != 0)
                        break;
                
                if (i == multiples.Count)
                    break;
                i = 0;
                num++;
            }

            Console.Write(num);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem6() //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
        {
            stopWatch.Restart();

            limit = 100;
            long sumsq = 0;
            
            long sqsum = (limit * (limit + 1)) / 2;

            Console.Write("Problem 6: ");

            for (int i = 1; i <= limit; i++)
                sumsq += (i * i);
            
            
            sqsum = sqsum * sqsum;

            Console.Write(sqsum-sumsq);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem7() //What is the 10001st prime number?
        {
            stopWatch.Restart();

            limit = 10001;
            
            int num = 2;
            int primeCount = 0;
            int i;
            bool breakBoth = false;

            Console.Write("Problem 7: ");

            while (primeCount < limit)
            {
                for (i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        breakBoth = true;
                        break;
                    }
                    if (breakBoth) break;
                }
                if (!breakBoth)
                    primeCount++;
                num++;
                breakBoth = false;
            }
            Console.Write(num - 1);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem8() //Find the greatest product of five consecutive digits in the 1000-digit number.
        {
            stopWatch.Restart();

            int intChar, product;
            int maxProduct = 0;
            string bigNum =
                "73167176531330624919225119674426574742355349194934" +
                "96983520312774506326239578318016984801869478851843" +
                "85861560789112949495459501737958331952853208805511" +
                "12540698747158523863050715693290963295227443043557" +
                "66896648950445244523161731856403098711121722383113" +
                "62229893423380308135336276614282806444486645238749" +
                "30358907296290491560440772390713810515859307960866" +
                "70172427121883998797908792274921901699720888093776" +
                "65727333001053367881220235421809751254540594752243" +
                "52584907711670556013604839586446706324415722155397" +
                "53697817977846174064955149290862569321978468622482" +
                "83972241375657056057490261407972968652414535100474" +
                "82166370484403199890008895243450658541227588666881" +
                "16427171479924442928230863465674813919123162824586" +
                "17866458359124566529476545682848912883142607690042" +
                "24219022671055626321111109370544217506941658960408" +
                "07198403850962455444362981230987879927244284909188" +
                "84580156166097919133875499200524063689912560717606" +
                "05886116467109405077541002256983155200055935729725" +
                "71636269561882670428252483600823257530420752963450";


            Console.Write("Problem 8: ");

            for (int i = 0; i < bigNum.Length - 5; i++)
            {
                product = 1;
                for (int j = i; j < i + 5; j++)
                {
                    intChar = (int)Char.GetNumericValue(bigNum[j]);
                    product *= intChar;
                }
                if (product > maxProduct)
                    maxProduct = product;
            }

            Console.Write(maxProduct);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem9() //There exists exactly one Pythagorean triplet for which a + b + c = 1000. Find the product abc.
        {
            stopWatch.Restart();

            limit = 1000;
            int i;
            int product = 0;
            bool breakAll = false;

            Console.Write("Problem 9: ");

            for(int a = 0; a < limit; a++)
            {
                if (a % 3 == 0 || a % 4 == 0 || a % 5 == 0)
                {
                    if (a % 2 == 0)
                        i = 1;
                    else
                        i = 2;

                    for (int b = i; b < limit; b += 2)
                    {
                        if (b % 3 == 0 || b % 4 == 0 || b % 5 == 0)
                        {
                            for (int c = 1; c < limit; c += 2)
                            {
                                if (c % 3 == 0 || c % 4 == 0 || c % 5 == 0)
                                {
                                    if (c > b && c > a)
                                    {
                                        if ((Math.Pow(a, 2) + Math.Pow(b, 2)) == Math.Pow(c, 2))
                                            if (a + b + c == limit)
                                            {
                                                product = a * b * c;
                                                breakAll = true;
                                                break;
                                            }
                                    }
                                }
                            }
                            if (breakAll) break;
                        }   
                    }
                    if (breakAll) break;
                }
            }

            Console.Write(product);

            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public void problem10()   //Find the sum of all the primes below two million.
        {
            stopWatch.Restart();
            int primeLimit = 2000000;
            sum = 2;

            Console.Write("Problem 10: ");

            BitArray notPrime = new BitArray(primeLimit);
            notPrime.Set(2, false);

            for (int i = 3; i < primeLimit; i += 2)
            {
                if (!notPrime.Get(i))
                    sum += i;

                for (int j = 2 * i; j < primeLimit; j += i)
                    notPrime.Set(j, true);
            }

            Console.Write(sum);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

   }
}
