using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugging
{
    class TrickyStrings
    {
        static void Main()
        {

            string delimiter = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string saved = "";
            saved = GetText(delimiter, n, saved);

        }

        static string GetText(string delimiter, int n, string saved)
        {
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                if (i < n - 1)
                {
                    saved += text + delimiter;
                }
                else
                    saved += text;



            }
            Console.WriteLine(saved);
            return saved;
        }
    }
}
