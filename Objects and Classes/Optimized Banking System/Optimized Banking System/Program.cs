using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimized_Banking_System
{
   public class Program
    {
        public class BankAccount
        {
            public string name { get; set; }
            public string bank { get; set; }
            public decimal balance { get; set; }


        }
        public static void Main()
        {
            BankAccount bankAcc = new BankAccount();

            Dictionary<string, Dictionary<string, decimal>> dic = new Dictionary<string, Dictionary<string, decimal>>();

            var line = Console.ReadLine();

            while (line != "end")
            {
                var parts = line.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                bankAcc.bank = parts[0];
                bankAcc.name = parts[1];
                bankAcc.balance = decimal.Parse(parts[2]);

                if (!dic.ContainsKey(bankAcc.bank))
                    dic[bankAcc.bank] = new Dictionary<string, decimal>();

                if (!dic[bankAcc.bank].ContainsKey(bankAcc.name))
                    dic[bankAcc.bank][bankAcc.name] = 0;

                dic[bankAcc.bank][bankAcc.name] += bankAcc.balance;

                line = Console.ReadLine();
            }

            dic = dic
                .OrderByDescending(x => x.Value.Max(y => y.Value))
                
                .ToDictionary(x => x.Key , x => x.Value.ToDictionary(y => y.Key, y => y.Value));

            foreach (var kvp in dic)
            {
                foreach (var dictionary in kvp.Value)
                {

                    Console.WriteLine($"{dictionary.Key} -> {dictionary.Value} ({kvp.Key})");
                }
            }


        }
    }
}
