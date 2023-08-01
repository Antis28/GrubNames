using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        struct doc
        {
            public string text;
            public int number;

            public override string ToString()
            {
                return number.ToString();
            }
        }


        static void Main(string[] args)
        {
            var path = @"C:\Users\Antis\Desktop\111111111\sc\ДНР 2021";
            var t = Directory.EnumerateFiles(path, "*.doc").ToList();

            var l = new List<doc>();

            var c = path.Count();


            for (int i = 0; i < t.Count; i++)
            {
                var numberLength = 4;
                int result;


                var text = t[i].Substring(45 + 2, numberLength);

                while (!int.TryParse(text, out result) && numberLength > 0)
                {
                    text = t[i].Substring(45 + 2, --numberLength);
                }

                if (result != 0)
                {
                    l.Add(new doc { number = result, text = t[i] });
                }               
            }
            var e = l.OrderBy(x => x.number).ToList();

            using (var f = File.CreateText(path + "\\names.txt"))
            {
                var n = new StreamWriter(f.BaseStream, Encoding.UTF8);

                foreach (doc file in e)
                {
                    n.WriteLine(file.text);
                }   
            }
        }
    }
}
