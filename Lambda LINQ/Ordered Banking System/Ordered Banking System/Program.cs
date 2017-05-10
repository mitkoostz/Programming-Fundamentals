using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordered_Banking_System
{
    public class Program
    {
        public static void Main()
        {
                   
            Dictionary<string, Dictionary<string, decimal>> bankSystem = new Dictionary<string, Dictionary<string, decimal>>();

            var line = Console.ReadLine();
            while (line != "end")
            {
                var words = line.Split(new[] {' ','-','>' },StringSplitOptions.RemoveEmptyEntries);
                var bank = words[0];
                var accountName = words[1];
               

                var balance = decimal.Parse(words[2]);

                if (!bankSystem.ContainsKey(bank))
                    bankSystem[bank] = new Dictionary<string, decimal>();

                if (!bankSystem[bank].ContainsKey(accountName))
                    bankSystem[bank][accountName] = 0;

                bankSystem[bank][accountName] += balance;


                line = Console.ReadLine();
            }

                 bankSystem
                .OrderByDescending(x => x.Value.Sum(y => y.Value))
                .ThenByDescending(x => x.Value.Max(y => y.Value))
                .ToList()
                .ForEach(bank => bank.Value
                     .OrderByDescending(account => account.Value)
                     .ToList()
                     .ForEach(account => Console.WriteLine("{0} -> {1} ({2})",
                     account.Key,
                     account.Value,
                     bank.Key)
                     ));

           

        }
    }
}
