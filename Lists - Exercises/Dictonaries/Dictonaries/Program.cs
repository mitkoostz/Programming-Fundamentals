using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictonaries
{
    public class Dictonaries
    {
        public static void Main()
        {

            var text = Console.ReadLine().ToArray();
          

            Dictionary<char, int> times = new Dictionary<char, int>();

            foreach (var letter in text)
            {
                if (!times.ContainsKey(letter))
                {
                    
                    times[letter] = 0;
                }
                times[letter]++;
            }
            foreach (var item in times)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
