using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class DefaultValues
    {
        public static void Main()
        {

        var line = Console.ReadLine();

        Dictionary<string, string> pairs = new Dictionary<string, string>();

        while (line != "end")
        {
            //take input
            string[] splited = line.Split(new[] { ' ', '-', '>' },StringSplitOptions.RemoveEmptyEntries);
            var key = splited[0];
            var value = splited[1];

            //record input
            pairs[key] = value;

            line = Console.ReadLine();
        }

        //DefaultValue
        var lastWord = Console.ReadLine();



        var withNulls = pairs
            .Where(st => st.Value == "null")
            .ToDictionary(st => st.Key,st => lastWord);//save Default Value

        var noNulls = pairs
            .Where(st => st.Value != "null")
            .OrderByDescending(st => st.Value.Length)
            .ToDictionary(st => st.Key, st => st.Value);



        foreach (var item in noNulls)
        {
            Console.WriteLine($"{item.Key} <-> {item.Value}");
        }

        foreach (var item in withNulls)
        {
            Console.WriteLine($"{item.Key} <-> {item.Value}");
        }



    }
}

