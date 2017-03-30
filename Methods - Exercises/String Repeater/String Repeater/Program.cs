using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Repeater
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
          
            Console.WriteLine(StringRepeat(text, count));
        }

        private static string StringRepeat(string str,int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s = s + str;
            }
            return s;
        }
    }
}
