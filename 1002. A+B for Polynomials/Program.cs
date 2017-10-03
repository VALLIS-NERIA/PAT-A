using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1002.A_B_for_Polynomials {
    class Program {
        static void Main(string[] args) {
            Dictionary<int, float> pm1 = GetExp();
            Dictionary<int, float> pm2 = GetExp();
            //var pm3 = new Dictionary<int, float>();
            var toRemove = new List<int>();
            foreach (var i in pm1) {
                if (!pm2.ContainsKey(i.Key)) {
                    pm2.Add(i.Key,i.Value);
                }
                else {
                    pm2[i.Key] += i.Value;
                    if (pm2[i.Key] == 0) {
                        toRemove.Add(i.Key);
                    }
                }
            }
            // 去掉系数为0的项
            foreach (int i in toRemove) {
                pm2.Remove(i);
            }
            pm2 = pm2.OrderBy(p => p.Key).Reverse().ToDictionary(pair => pair.Key, pair => pair.Value);
            Console.Write(pm2.Count);
            foreach (var i in pm2) {
                Console.Write(string.Format(" {0} {1:F1}",i.Key,i.Value));
            }
            Console.WriteLine();
        }

        private static Dictionary<int, float> GetExp() {
            string[] line1 = Console.ReadLine().Split(' ');
            var pm1 = new Dictionary<int, float>();
            int n = int.Parse(line1[0]);
            int i = 1;
            while (n-- > 0) {
                int e = int.Parse(line1[i++]);
                float c = float.Parse(line1[i++]);
                pm1.Add(e, c);
            }
            return pm1;
        }
    }
}
