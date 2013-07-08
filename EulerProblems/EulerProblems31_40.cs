using System;
using System.Diagnostics;

namespace EulerProblems
{
    class EulerProblems31_40
    {
        private long limit;
        private Stopwatch stopWatch = new Stopwatch();

        public void runAll()
        {
            problem31();
            //problem32();
            //problem33();
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
    }
}
