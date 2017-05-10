using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceHolders
{
     public class PlaceHolders
    {
        public static void Main()
        {

            var inputLine = Console.ReadLine();


            while (inputLine != "end")
            {
                string[] partsOfAll = inputLine.Split(new[] {'-','>'},StringSplitOptions.RemoveEmptyEntries);


                string[] text = partsOfAll[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] words = partsOfAll[1].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);


                string result = string.Join(" ", text);
                var i = 0;
                var placeHolder = "{" + i.ToString() + "}";


                while (i < words.Length)
                {
                    result = result.Replace(placeHolder, words[i]);
                    i++;
                    placeHolder = "{" + i.ToString() + "}";
                }

                Console.WriteLine(result);

                
                inputLine = Console.ReadLine();
            }
           
        }
    }
}
