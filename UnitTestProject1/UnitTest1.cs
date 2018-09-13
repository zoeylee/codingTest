using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var myDict = this.ReadData();
            var text = ConsoleApp1.Program.Store(myDict);
            
            Console.WriteLine("textFile: {0}", text);

            var arr = ConsoleApp1.Program.Load(text);

            foreach (var pairs in arr)
            {
                foreach (var pair in pairs.Value)
                {
                    Console.WriteLine("Key: {0} Value: {1},{2}", pairs.Key.ToString(), pair.Key, pair.Value);
                }
            }
            


        }
        [TestMethod]
        public void TestMethod2()
        {
            var myDict = this.ReadData2();
            var points = ConsoleApp02.Program.Mapper(myDict);
            var result = ConsoleApp02.Program.Find(points);

            foreach (var point in result)
            {
                Console.WriteLine("edge: {0}->{1}", point.Start, point.Next);
            }
            Console.WriteLine("total: {0}", points.Sum(x => x.Weight));


        }
        public Dictionary<int, Dictionary<string, string>> ReadData()
        {
            Dictionary<int, Dictionary<string, string>> dict = new Dictionary<int, Dictionary<string, string>>();
            dict.Add(0, new Dictionary<string, string>() { { "key1", "value1" }, { "key2", "value2" } });
            dict.Add(1, new Dictionary<string, string>() { { "keyA", "valueA" } });
            return dict;
        }

        public Dictionary<string, int> ReadData2()
        {
            var points = new Dictionary<string, int> { { "A", 1 }, { "B", 2 }, { "C", 2 } };

            return points;
        }
    }
}
