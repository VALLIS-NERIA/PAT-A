using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1001.A_B_Format {
    class Program {
        static void Main(string[] args) {
            while (true) {
                var input = Console.ReadLine().Split(' ');
                int x = int.Parse(input[0]);
                int y = int.Parse(input[1]);
                int z = x + y;
                Console.WriteLine(string.Format("{0:N0}", z));
                ;
            }
        }
    }
}