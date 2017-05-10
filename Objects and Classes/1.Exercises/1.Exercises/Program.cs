using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace exer
{

    public class Exercises
    {
        public static void Main()
        {
            //CREATE LIST OF CLASSES
            List<Exercise> exercises = new List<Exercise>();

            var line = Console.ReadLine();

            while (line != "go go go")
            {
                var lineParams = line.Split(new[] {' ','-',',','>' },StringSplitOptions.RemoveEmptyEntries);

                var topic = lineParams[0];
                var courseName = lineParams[1];
                var judgeLink = lineParams[2];
                //skip topic,courseName and judgeLink and take all ExercisesNames
                List<string> problems = lineParams.Skip(3).ToList();

                //make the class Exercise enable to use
                Exercise newExercise = new Exercise();

                //save data to created newExercise class
                newExercise.Topic = topic;
                newExercise.CourseName = courseName;
                newExercise.JudgeContestLink = judgeLink;
                newExercise.Problems = problems;

                //add class(with it data) in List of classes Ecercise
                exercises.Add(newExercise);

                line = Console.ReadLine();
            }

            foreach (var exercise in exercises)
            {
                Console.WriteLine("Exercises: {0}", exercise.Topic);
                Console.WriteLine($"Problems for exercises and homework for the \"{exercise.CourseName}\" course @ SoftUni.");
                Console.WriteLine("Check your solutions here: {0}",exercise.JudgeContestLink);
                int count = 1;

                // the second foreach is to get data of list created in class 
                foreach (var problem in exercise.Problems)
                {
                    Console.WriteLine("{0}. {1}",count,problem);
                    count++;
                }


            }
        }
    }
}

