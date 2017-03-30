using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMinimal();

        }

        private static void GetMinimal()
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            int result = GetMin(number1, number2);

            if (result < number3)
            {
                Console.WriteLine(result);
            }
            else
                Console.WriteLine(number3);
        }

        private static int GetMin(int a, int b)
        {
            if (a < b)
            {
                return a;
            }
            else
                return b;
        }
    }
}
