using System;

namespace EulerProblems
{
    class EulerMain
    {
        static void Main(string[] args)
        {
            var eu1 = new Euler1_10();
            var eu11 = new Euler11_20();
            var eu21 = new Euler21_30();
            var eu31 = new Euler31_40();
            var eu51 = new Euler51_60();
            var eu61 = new Euler61_70();

            eu1.runAll();
            Console.ReadKey();
        }
    }
}
