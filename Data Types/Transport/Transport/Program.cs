using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)n / 24);

            Console.WriteLine(courses);


        }
    }
}
