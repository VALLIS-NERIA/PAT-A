using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1003.Emergency {
    class Program {
#if VS
        [DebuggerDisplay("{" + nameof(String) + "}")]
#endif
        class Path {
            public List<Node> Route;
            public int Length;
            public int Value;
#if VS
            public string String {
                get {
                    string s = $"{Length} / {Value} :: ";
                    foreach (var node in ((IEnumerable<Node>) Route).Reverse()) {
                        s += $"{node.Number}->";
                    }
                    s = s.Remove(s.LastIndexOf("->"));
                    return s;
                }
            }
#endif
            public Path(Path other) {
                Route = new List<Node>(other.Route);
                Length = other.Length;
                Value = other.Value;
            }

            public Path() { }

            public void Add(Node n) {
                var l = Route.Last();
                Route.Add(n);
                Length += l.Links[n];
                Value += n.Value;
            }

            public void Pop() {
                var l = Route.Last();
                Route.RemoveAt(Route.Count - 1);
                var l2 = Route.Last();
                Length -= l2.Links[l];
                Value -= l.Value;
            }
        }
#if VS
        [DebuggerDisplay("{Node " + nameof(Number) + "}")]
#endif
        class Node {
            public int Number;

            public Dictionary<Node, int> Links;
            public int Value;

            public Node() { Links = new Dictionary<Node, int>(); }

            public static int min = int.MaxValue;
            public static int count = 0;
            public static int maxValue = 0;

            private bool visited = false;

            // 自顶向下，需要一个memo，pathSoFar应当已包含this
            public List<Path> FindPathNew(Node dest, bool crop = true, Path pathSoFar = null) {
                var availabePaths = new List<Path>();
                if (pathSoFar == null) {
                    pathSoFar = new Path {Route = new List<Node> {this}, Length = 0, Value = this.Value};
                }
                // 已查找到终点
                if (this == dest) {
                    Path path = new Path(pathSoFar);

                    if (path.Length < min) {
                        min = path.Length;
                        count = 0;
                        maxValue = path.Value;
                    }
                    if (path.Length == min) {
                        count++;
                        if (path.Value > maxValue) {
                            maxValue = path.Value;
                        }
                    }
                    availabePaths.Add(path);
                    return availabePaths;
                }

                this.visited = true;
                foreach (var link in this.Links) {
                    Node linkNode = link.Key;
                    int linkLength = link.Value;
                    pathSoFar.Add(linkNode);
                    // 剪枝
                    if (crop) {
                        if (pathSoFar.Length > min || linkNode.visited) {
                            pathSoFar.Pop();
                            continue;
                        }
                    }
                    var ret = linkNode.FindPathNew(dest, crop, pathSoFar);
                    if (ret != null) {
                        availabePaths = availabePaths.Concat(ret).ToList();
                    }
                    pathSoFar.Pop();
                }
                this.visited = false;
                if (availabePaths.Count == 0) {
                    return null;
                }
                else {
                    return availabePaths;
                }
            }

            // 自底向上会超时
            public List<Path> FindPath(Node src, Node dest) {
                var availabePaths = new List<Path>();
                // 自己就是
                if (this == dest) {
                    availabePaths.Add(new Path {Route = new List<Node> {dest}, Length = 0, Value = dest.Value});
                    return availabePaths;
                }
                //var path = new List<Node>(_path);
                //path.Add(this);
                this.visited = true;
                foreach (var link in this.Links) {
                    // 环
                    Node linkNode = link.Key;
                    int linkLength = link.Value;
                    if (linkNode.visited) {
                        continue;
                    }
                    // 否则递归查找
                    var ret = linkNode.FindPath(src, dest);
                    if (ret == null) {
                        continue;
                    }
                    foreach (var p in ret) {
                        //p.Route.Add(this);
                        p.Length += linkLength;
                        p.Value += this.Value;

                        if (p.Length > min) {
                            continue;
                        }
                        availabePaths.Add(p);
                        if (this == src) {
                            if (p.Length < min) {
                                min = p.Length;
                                count = 0;
                                maxValue = p.Value;
                            }
                            if (p.Length == min) {
                                count++;
                                if (p.Value > maxValue) {
                                    maxValue = p.Value;
                                }
                            }
                        }
                    }
                }
                //path.Remove(this);
                this.visited = false;
                if (availabePaths.Count == 0) {
                    return null;
                }
                else {
                    return availabePaths;
                }
            }

            public void Link(Node other, int length) {
                if (!this.Links.ContainsKey(other)) {
                    this.Links.Add(other, length);
                }
                if (!other.Links.ContainsKey(this)) {
                    other.Links.Add(this, length);
                }
            }
        }

        static void Main(string[] args) {
            var line = Console.ReadLine().Split(' ');
            int n = int.Parse(line[0]);
            int m = int.Parse(line[1]);
            int c1 = int.Parse(line[2]);
            int c2 = int.Parse(line[3]);
            var cities = new List<Node>();
            line = Console.ReadLine().Split(' ');
            int i = 0;
            foreach (var s in line) {
                int item = int.Parse(s);
                cities.Add(new Node {Value = item, Number = i++});
            }
            while (m-- > 0) {
                line = Console.ReadLine().Split(' ');
                cities[int.Parse(line[0])].Link(cities[int.Parse(line[1])], int.Parse(line[2]));
            }
            var paths = cities[c1].FindPathNew(cities[c2]);
            Console.WriteLine(Node.count + " " + Node.maxValue);
            ;
        }
    }
}