using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerProblems
{
    class EulerMain
    {
        static void Main(string[] args)
        {
            var eu1 = new EulerProblems1_10();
            var eu11 = new EulerProblems11_20();
            var eu61 = new EulerProblems61_70();

            eu1.problem4();
            eu11.runAll();
            eu61.problem67();
            Console.ReadKey();
        }
    }
}
