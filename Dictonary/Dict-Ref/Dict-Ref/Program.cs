using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dict_Ref
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine().Split(' ');

            
            while (!text.Contains("end"))
            {

                Console.WriteLine(text[0]);

                text = Console.ReadLine().Split(' ');
            }

        }
    }
}
