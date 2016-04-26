using System;

namespace CollegeCourses
{
    public class CollegeCoursesApplication
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Enter courses here...");
            string input = Console.ReadLine();
            string[] inputArray;

            // get user input or assign default value
            if (input == null)
                inputArray = ApplicationLogic.courses;
            else
            {

            }
            Console.Read();
        }
    }

    public static class ApplicationLogic
    {
        public static string[] courses = new string[]
        {
            "Introduction to Paper Airplanes: ",
            "Advanced Throwing Techniques: Introduction to Paper Airplanes",
            "History of Cubicle Siege Engines: Rubber Band Catapults 101",
            "Advanced Office Warfare: History of Cubicle Siege Engines",
            "Rubber Band Catapults 101: ",
            "Paper Jet Engines: Introduction to Paper Airplanes"
        };


    }
}
