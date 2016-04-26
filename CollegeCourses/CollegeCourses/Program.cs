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
                inputArray = input.Split(',');

            // build list
            if (ApplicationLogic.IsValid(inputArray))
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

        public static bool IsValid(string[] inputArray)
        {
            // verify that each item in the array has a value followed by a colon followed by at least a space
            foreach (string item in inputArray)
            {
                // get location of colon and space
                int location = item.IndexOf(": ");
                if (location < 1) return false;

                // make sure there is only one colon space combo
                location = item.IndexOf(": ", location + 1);
                if (location > -1) return false;
            }
            return true;
        }

        public static string OrderCoursesByPrerequisites(string[] inputArray, string prerequisite)
        {
            string output = "a, b";
            return output;
        }

    }
}
