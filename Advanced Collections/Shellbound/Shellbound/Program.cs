using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shellbound
{
    class Shellbound
    {
        static void Main()
        {
            var dic = new Dictionary<string, HashSet<int>>();

            var line = Console.ReadLine().Split(' ');

            while (line[0] != "Aggregate")
            {
                

                var city = line[0].ToString();

                if (!line.Contains("Aggregate"))
                {
                    var shell = int.Parse(line[1].ToString());
                    addShell(dic, city, shell);
                }
               

                


              line = Console.ReadLine().Split(' ');
            }

            
            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(", ",item.Value)}");
            }

        }

        private static void addShell(Dictionary<string, HashSet<int>> dic, string city, int shell)
        {

            if (!dic.ContainsKey(city))
            {
                dic[city] = new HashSet<int>();
            }

            dic[city].Add(shell);
        }
    }
}
