using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006.Sign_In_and_Sign_Out_sharp {
    class Record {
        public string ID;
        public DateTime SignIn;
        public DateTime SignOut;

        public Record(string s) {
            var line = s.Split(' ');
            ID = line[0];
            SignIn = Convert.ToDateTime(line[1]);
            SignOut = Convert.ToDateTime(line[2]);
        }
    }
    class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            var list = new List<Record>();
            while (n-- > 0) {
                list.Add(new Record(Console.ReadLine()));
            }
            var first = list.OrderBy(r => r.SignIn).First();
            var last = list.OrderBy(r => r.SignOut).Last();
            Console.WriteLine(first.ID+" "+last.ID);
            
        }
    }
}
