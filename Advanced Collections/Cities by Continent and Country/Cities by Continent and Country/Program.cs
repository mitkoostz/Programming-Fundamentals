using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities_by_Continent_and_Country
{
    public class CitiesByContinentAndCountry
    {
        public static void Main()
        {
                                  //continents  //countries     //cities
            var dic = new Dictionary<string, Dictionary<string,List<string>>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');

                add(dic, line[0], line[1],line[2]);
            }



           

        }

        private static void add(Dictionary<string, Dictionary<string, List<string>>> dic, string  continent, string country, string city)
        {
            if (!dic.ContainsKey(continent))
                dic[continent] = new Dictionary<string, List<string>>();

            if (!dic[continent].ContainsKey(country))
                dic[continent][country] = new List<string>();

            dic[continent][country].Add(city);
        }
    }
}
