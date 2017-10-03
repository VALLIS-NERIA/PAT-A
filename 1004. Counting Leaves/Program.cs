using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004.Counting_Leaves {
    class Node {
        public List<Node> Children;


        public Node() {
            Children = new List<Node>();
            //Level = 0;
        }

        internal static int[] stats = new int[102];
        internal static int maxLevel = 0;

        public void Dfs(int level) {
            if (level > maxLevel) {
                maxLevel = level;
            }
            if (this.Children.Count == 0) {
                stats[level]++;
            }
            else {
                foreach (Node child in Children) {
                    child.Dfs(level + 1);
                }
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            var line = Console.ReadLine().Split(' ');
            int n = int.Parse(line[0]);
            int m = int.Parse(line[1]);

            var nodes = new Node[101];
            for (int i = 0; i < 101; i++) {
                nodes[i] = new Node();
            }
            while (m-- > 0) {
#warning 纸张傻逼出题人往输入里面塞了空行
                var s = Console.ReadLine();
                if (s == "") {
                    m++;
                    continue;
                }
                line = s.Split(' ');
                int i = 0;
                while (line[i] == "") i++;
                var id = int.Parse(line[0]);
                while (line[i] == "") i++;
                int k = int.Parse(line[1]);
                Node node = nodes[id];

                for (; i < k + 2; i++) {
                    var childId = int.Parse(line[i]);
                    Node child = nodes[childId];
                    node.Children.Add(child);
                }
            }
            nodes[1].Dfs(0);
            for (int i = 0; i <= Node.maxLevel; i++) {
                var x = Node.stats[i];
                if (i != Node.maxLevel) {
                    Console.Write(x + " ");
                }
                else {
                    Console.WriteLine(x);
                }
            }
            ;
        }
    }
}





