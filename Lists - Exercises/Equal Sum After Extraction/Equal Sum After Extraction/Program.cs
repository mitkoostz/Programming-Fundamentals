using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Sum_After_Extraction
{
    class SumAfterExtraction
    {
        public static void Main()
        {

            var list1 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var list2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var sumList1 = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                sumList1 += list1[i];
            }



            for (int i = 0; i < list1.Count; i++)
            {
                if (list2.Contains(list1[i]))
                {
                    list2.Remove(list1[i]);
                }
            }
            var sumList2 = 0;
            for (int i = 0; i < list2.Count; i++)
            {
                sumList2 += list2[i];
            }

            var diff = Math.Abs(sumList1 - sumList2);
            if(sumList1 == sumList2)
            {
                Console.WriteLine("Yes. Sum: " + sumList1);
            }
            else
                Console.WriteLine("No. Diff: " + diff);
        

        }
    }
}
