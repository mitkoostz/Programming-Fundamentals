using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nth_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            int index = int.Parse(Console.ReadLine());

            FindNumber(numbers,index);
        }

        private static void FindNumber(string str,int index)
        {

            Console.WriteLine(str[str.Length-index]);
            
        }
    }
}
