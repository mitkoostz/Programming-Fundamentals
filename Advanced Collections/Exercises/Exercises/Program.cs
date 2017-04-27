using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class AdvancedCollections
    {
        public static void Main()
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var name = line[0];
                var grade = Double.Parse(line[1]);

                addStudent(students, name, grade);

            }

            //enter in every student - list with grades
            foreach (var pair in students)
            {
                //student name
                var name = pair.Key;
                                   
                //list with student grades
                var studentGrades = pair.Value;

                //average of list with student grades
                var avg = studentGrades.Average();
                Console.Write($"{name} -> ");

                //enter in list to get grades
                foreach (var grade in studentGrades)
                {
                    //single grade
                    Console.Write($"{grade:F2} "); 

                }
                //print average of grades 
                Console.WriteLine($"(avg: {avg:F2})");

            }

        }

        private static void addStudent(Dictionary<string, List<double>> students, string name, double grade)
        {
            if (!students.Keys.Contains(name))
                students[name] = new List<double>();

            students[name].Add(grade);
        }
    }
}
