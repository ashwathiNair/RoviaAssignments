using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictnry<int, string>();
            dict.Add(100, "100");
            Console.WriteLine(dict.Capacity);

            for (int i = 0; i < 10; i++)
            {
                dict.Add(i, (i + 1).ToString());
            }

            Console.WriteLine(dict.Capacity);

            for (int i = 10; i < 20; i++)
            {
                dict.Add(i, (i + 1).ToString());
            }

            Console.WriteLine(dict.Capacity);

            var myValue = dict.Find(3);
            Console.WriteLine(myValue);

            var keyExists = dict.ContainsKey(4);
            Console.WriteLine(keyExists);


            

            Console.ReadKey();
        }
    }
}
