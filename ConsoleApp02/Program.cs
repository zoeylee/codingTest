using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp02
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var arr = ReadData();
            var points = Mapper(arr);
            var res = Find(points);
            foreach (var point in res)
            {
                Console.WriteLine("edge: {0}->{1}", point.Start, point.Next);
            }
            Console.WriteLine("total: {0}", points.Sum(x => x.Weight));
        }

        static public Dictionary<string, int> ReadData()
        {
            var points = new Dictionary<string, int> { { "A", 1 }, { "B", 2 }, { "C", 2 } };

            return points;
        }

        static public List<Point> Mapper(Dictionary<string, int> points)
        {
            var result = new List<Point>();
            int index = 0;
            foreach (var point in points)
            {
                result.Add(new Point()
                {
                    Start = point.Key,
                    Index = index,
                    Weight = point.Value
                }
                );
                index++;
            }
            return result;
        }

        static public List<Point> Find(List<Point> points)
        {
            for (var i = 0; i < points.Count; i++)
            {
                if (points[i].IsVisited) { continue; }
                var subsum = 0;
                for (var j = i + 1; j < points.Count; j++)
                {
                    if (subsum >= points[i].Weight + points[j].Weight) { continue; }
                    points[i].IsVisited = true;
                    points[i].Next = points[j].Start;
                    subsum = points[i].Weight + points[j].Weight;

                }
                if ((i + 1) == points.Count)
                {
                    points[i].Next = points[0].Start;
                }
            }

            return points;
        }
    }
    public class Point
    {
        public string Start;
        public string Next;
        public int Index;
        public int Weight;
        public bool IsVisited;
    }

}
