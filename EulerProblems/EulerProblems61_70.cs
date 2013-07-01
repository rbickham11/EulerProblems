using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace EulerProblems
{
    public  class EulerProblems61_70
    {
        private  Stopwatch stopWatch = new Stopwatch();

        public void problem67() //Find the maximum total from top to bottom in a triangle with one-hundred rows.
        {
            stopWatch.Restart();

            int numLines = 100;
            int[,] pyramid = new int[numLines, numLines];
            int i, j;
            string[] nums;

            Console.Write("Problem 67: ");

            using (StreamReader sr = new StreamReader("triangle.txt"))
            {
                for (i = 0; i < numLines; i++)
                {
                    nums = sr.ReadLine().Split(' ');
                    for (j = 0; j <= i; j++)
                        pyramid[i, j] = Convert.ToInt32(nums[j]);
                }
            }

            for (i = numLines - 2; i >= 0; i--)
            {
                for (j = 0; j < numLines; j++)
                {
                    if (pyramid[i, j] == 0)
                        break;
                    pyramid[i, j] += Math.Max(pyramid[i + 1, j], pyramid[i + 1, j + 1]);
                }
            }

            Console.Write(pyramid[0, 0]);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }
    }
}
