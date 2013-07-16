using System.Collections;
using System.Collections.Generic;

namespace EulerProblems
{
    public class EulerToolbox
    {
        public int factorial(int n)
        {
            if (n == 0)
                return 1;
            int m = n;
            for (int i = 1; i < n; i++)
                m *= i;
            return m;
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

        public List<int> getPrimes(int n)
        {
            BitArray notPrime = new BitArray(n + 1);
            List<int> primeList = new List<int>();
            int i, j;

            for (i = 2; i <= n; i++)
            {
                if (!notPrime.Get(i))
                {
                    primeList.Add(i);
                    for (j = i * 2; j <= n; j += i)
                        notPrime.Set(j, true);
                }
            }

            return primeList;
        }

        public bool isPrime(int n, ref List<int> primeList)
        {
            for (int i = 0; primeList[i] <= n; i++)
                if (primeList[i] == n)
                    return true;
            return false;
        }

        public int numDivisors(long n)
        {
            int divCount = 1;
            int i = 0;
            int j = 3;

            if (n % 2 == 0)
            {
                n /= 2;
                while (n % 2 == 0)
                {
                    i++;
                    n /= 2;
                }

                divCount *= (i + 1);
            }

            while (n != 1)
            {
                i = 0;
                while (n % j == 0)
                {
                    i++;
                    n /= j;
                }

                divCount *= (i + 1);
                j += 2;
            }

            return divCount;

        }
    }
}