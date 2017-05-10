using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

    public class RegisteredUsers
    {
        public static void Main()
        {
           var registeredUsers = new Dictionary<string, DateTime>();

        var line = Console.ReadLine();

        while (line != "end")
        {
            string[] words = line.Split(new[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var user = words[0];
            var date = DateTime.ParseExact(words[1],"dd/MM/yyyy",CultureInfo.InvariantCulture);

            registeredUsers[user] = date;

            line = Console.ReadLine();
        }

        Dictionary<string, DateTime> orderedUsers = registeredUsers
            .Reverse()
            .OrderBy(x => x.Value)
            .Take(5)
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var user in orderedUsers)
        {
            Console.WriteLine("{0}",user.Key);
        }

        }
    }

