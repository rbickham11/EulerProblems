using System;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EulerProblems
{
    class Euler51_60 : EulerToolbox
    {
        private Stopwatch stopWatch = new Stopwatch();
        
        public void problem54() // Given a text file containing 1000 poker hands, how many hands does Player 1 win?
        {
            stopWatch.Restart();
            Console.Write("Problem 54: ");

            List<string> lines;
            int i, j, k, h1Rank, h2Rank;
            int h1Wins = 0;
            int h2Wins = 0;
            List<char> cardVals = new List<char>(){ '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
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
                lines = new List<string>(sr.ReadToEnd().Split('\n'));

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

                h1Rank = valueCheck(h1Values);
                h2Rank = valueCheck(h2Values);

                if (h1Rank == -2 || h2Rank == -2)
                {
                    Console.WriteLine("One or more hands are invalid");
                    continue;
                }
                if (h1Rank == -1 || h2Rank == -1)
                {
                    if (h1Rank == -1)
                    {
                        k = 1;
                        for (j = 0; j < 5; j++)
                        {
                            suits[j] = lines[i][k];
                            k += 3;
                        }
                        h1Rank = suitCheck(h1Values, suits);
                    }
                    if (h2Rank == -1)
                    {
                        k = 16;
                        for (j = 0; j < 5; j++)
                        {
                            suits[j] = lines[i][k];
                            k += 3;
                        }
                        h2Rank = suitCheck(h2Values, suits);
                    }
                }
                if (h1Rank > h2Rank)
                    h1Wins++;
                else if (h1Rank < h2Rank)
                    h2Wins++;
                else if (h1Rank == h2Rank)
                {
                    if (h1Values.Distinct().Count() != 5)
                    {
                        shiftVals(h1Rank, ref h1Values);
                        shiftVals(h2Rank, ref h2Values);
                    }
                    for (j = 4; j >= 0; j--)
                    {
                        if (h1Values[j] > h2Values[j])
                        {
                            h1Wins++;
                            break;
                        }
                        else if (h1Values[j] < h2Values[j])
                        {
                            h2Wins++;
                            break;
                        }
                        if (j == 0)
                            Console.Write("Chop");
                    }

                }
                
            }

            Console.Write(h1Wins);
            stopWatch.Stop();
            Console.WriteLine("  (" + stopWatch.ElapsedMilliseconds + "ms" + ")");
        }

        public int valueCheck(List<int> handValues)
        {
            int distinctCount = handValues.Distinct().Count();

            switch (distinctCount)
            {
                case 2:
                    if ((handValues[0] != handValues[1]) || (handValues[3] != handValues[4]))
                        return 7; //Four of a Kind
                    else
                        return 6; //Full House
                case 3:
                    if ((handValues[0] == handValues[2]) || (handValues[1] == handValues[3]) || (handValues[2] == handValues[4]))
                        return 3; //Three of a Kind
                    else
                        return 2; //Two Pair
                case 4:
                    return 1; //Pair
                case 5:
                    return -1; //Need to check for Flush (Could also be straight or high card).
                default:
                    Console.Write("Invalid Hand");
                    return -2;
            }
        }

        public int suitCheck(List<int> handValues, List<char> suits)
        {
            bool isStraight = true;
            int j = 5;
            
            if (handValues[0] == 0 && handValues[1] == 1 && handValues[4] == 12)
                j = 4;
            for (int i = 1; i < j; i++)
            {
                if (handValues[i] != handValues[i - 1] + 1)
                {
                    isStraight = false;
                    break;
                }
            }
           
            if (isStraight)
            {
                if (suits.Distinct().Count() == 1)
                    return 8; //Straight Flush
                else
                    return 4; //Straight
            }
            if (suits.Distinct().Count() == 1)
                return 5; //Flush
            else
                return 0; //High Card
        }

        public void shiftVals(int rank, ref List<int> handValues)
        {
            int duplicate;
            switch (rank)
            {
                case 1: //Pair
                case 2: //Two Pair
                    for (int i = 0; i < 3; i++)
                    {
                        if (handValues[i] == handValues[i + 1])
                        {
                            duplicate = handValues[i];
                            handValues.RemoveRange(i, 2);
                            handValues.Add(duplicate);
                            handValues.Add(duplicate);
                            break;
                        }
                    }
                    if(rank == 1)
                        break;
                    
                    for (int i = 0; i < 2; i++)
                    {
                        if (handValues[i] == handValues[i + 1])
                        {
                            duplicate = handValues[i];
                            handValues.RemoveRange(i, 2);
                            handValues.Add(duplicate);
                            handValues.Add(duplicate);
                            break;
                        }
                    }
                    break;
                case 3: //Three of a Kind                  
                    for (int i = 0; i < 2; i++)
                    {
                        if (handValues[i] == handValues[i + 2])
                        {
                            duplicate = handValues[i];
                            handValues.RemoveRange(i, 3);
                            for (int j = 0; j < 3; j++)
                                handValues.Add(duplicate);
                            break;
                        }
                    }
                    break;
                case 6: //Full House
                    if (handValues[0] == handValues[2])
                    {
                        duplicate = handValues[0];
                        handValues.RemoveRange(0, 3);
                        for (int j = 0; j < 3; j++)
                            handValues.Add(duplicate);
                    }
                    break;
                case 7: //Four of a Kind
                    if (handValues[1] != handValues[4])
                    {
                        duplicate = handValues[4]; //(Extra value instead of duplicate here)
                        handValues.RemoveAt(4);
                        for (int j = 0; j < 3; j++)
                            handValues.Insert(0, 4);
                    }
                    break;
                default:
                    Console.WriteLine("shiftVals invalid hand");
                    break;
            }
        }
    }
}
