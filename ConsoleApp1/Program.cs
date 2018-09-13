using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            /// questoin 1
            var dict = ReadData();
            var text = Store(dict);
            Console.WriteLine("textFile: {0}", text);

            var arr = Load(text);
            foreach (var pairs in arr)
            {
                foreach (var pair in pairs.Value)
                {
                    Console.WriteLine("Key: {0} Value: {1},{2}", pairs.Key.ToString(), pair.Key, pair.Value);
                }
            }
        }

        static public Dictionary<int, Dictionary<string, string>> ReadData()
        {
            Dictionary<int, Dictionary<string, string>> dict = new Dictionary<int, Dictionary<string, string>>();
            dict.Add(0, new Dictionary<string, string>() { { "key1", "value1" }, { "key2", "value2" } });
            dict.Add(1, new Dictionary<string, string>() { { "keyA", "valueA" } });
            return dict;
        }
        
        static public string Store(Dictionary<int, Dictionary<string, string>> input)
        {
            var result = new List<string>();
            foreach (var entry in input)
            {
                var temp = entry.Value.Select(x => x.Key + "=" + x.Value).Aggregate((s1, s2) => s1 + ";" + s2);
                result.Add(temp);
            }

            return result.Aggregate((s1, s2) => s1 + "\n" + s2);

        }

        static public Dictionary<int, Dictionary<string, string>> Load(string dataStore)
        {
            string[] datas = dataStore.Split('\n');
            Dictionary<int, Dictionary<string, string>> dict = new Dictionary<int, Dictionary<string, string>>();
            for (var i =0; i< datas.Length;i++)
            {
                var dp = datas[i].Split(';').Select(x => x).ToDictionary(k => k.Split('=').First(), v => v.Split('=').Last());
                dict.Add(i, dp);
            }

            return dict;


        }
    }
}
