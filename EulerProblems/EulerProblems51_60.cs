using System;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EulerProblems
{
    class EulerProblems51_60 : EulerToolbox
    {
        private long limit;
        private Stopwatch stopWatch = new Stopwatch();
        
        public struct card
        {
            public char value, suit;
        }

        public void problem54() // Given a text file containing 1000 poker hands, how many hands does Player 1 win?
        {
            stopWatch.Restart();
            Console.Write("Problem 54: ");

            List<string> lines;
            int i, j, k, distCount, rank;
            List<char> cardVals = new List<char>(){ '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
            List<string> hands = new List<string>() { "High Card", "Pair", "Two Pair", "Three of a Kind", "Straight", "Flush", "Full House", "Four of a Kind", "Straight Flush" };
            List<char> charValues = new List<char>();
            List<int> h1Values = new List<int>();
            List<int> h2Values = new List<int>();
            List<char> suits = new List<char>();

            for (i = 0; i < 5; i++)
            {
                charValues.Add('0');
                h1Values.Add(0);
                h2Values.Add(0);
                suits.Add('0');
            }

            using (StreamReader sr = new StreamReader("poker.txt"))
                lines = new List<string>(sr.ReadToEnd().Replace("\"", "").Split('\n'));

            for (i = 0; i < lines.Count; i++)
            {
                k = 0;
                for (j = 0; j < 5; j++)
                {
                    charValues[j] = lines[i][k];
                    h1Values[j] = cardVals.IndexOf(charValues[j]);
                    k += 3;
                }
                for (j = 0; j < 5; j++)
                {
                    charValues[j] = lines[i][k];
                    h2Values[j] = cardVals.IndexOf(charValues[j]);
                    k += 3;
                }

                h1Values.Sort();
                h2Values.Sort();

                distCount = h1Values.Distinct().Count();

                for (k = 0; k < 2; k++)
                {
                    switch (distCount)
                    {
                        case 2:
                            Console.WriteLine(i + " " + k + " Full House or Four of a Kind");
                            break;
                        case 3:
                            Console.WriteLine(i + " " + k + " Two Pair or Three of a Kind");
                            break;
                        case 4:
                            Console.WriteLine(i + " " + k + " Pair");
                            break;
                        case 5:
                            Console.WriteLine(i + " " + k + " High Card or Straight or Flush or Straight Flush");
                            break;
                        default:
                            Console.Write("Invalid Hand");
                            break;
                    }
                    distCount = h2Values.Distinct().Count();
                }
            }

            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }
    }
}
