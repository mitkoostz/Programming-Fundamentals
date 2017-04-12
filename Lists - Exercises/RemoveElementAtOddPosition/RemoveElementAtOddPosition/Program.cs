using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveElementAtOddPosition
{
    class RemoveElementAtOddPosition
    {
        public static void Main()
        {

            var list = Console.ReadLine().Split(' ').ToList();

            var indexToSave = 1;

            var inputedListCount = list.Count;

            var result = new List<string>();

            for (int i = 0; i < inputedListCount; i++)
            {

                if (i == indexToSave)
                {
                    result.Add(list[i]);
                    indexToSave += 2;
                }

                
            }

            Console.WriteLine(string.Join("",result));

        }
    }
}
