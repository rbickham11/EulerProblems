﻿using System;

namespace EulerProblems
{
    class EulerMain
    {
        static void Main(string[] args)
        {
            var eu1 = new EulerProblems1_10();
            var eu11 = new EulerProblems11_20();
            var eu21 = new EulerProblems21_30();
            var eu31 = new EulerProblems31_40();
            var eu61 = new EulerProblems61_70();

            eu31.problem31();
            Console.ReadKey();
        }
    }
}
