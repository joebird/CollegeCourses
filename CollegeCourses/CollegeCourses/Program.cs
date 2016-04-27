using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeCourses
{
    public class CollegeCoursesApplication
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Enter courses below (course1: prereq1, course2: prereq2, etc.) or type exit to quit:");
            string input; // = Console.ReadLine();
            while ((input = Console.ReadLine()) != "exit")
            {
                string[] inputArray;

                // get user input or assign default value
                if (input == "")
                    inputArray = ApplicationLogic.courses;
                else
                    inputArray = input.Split(new string[] { ", " }, StringSplitOptions.None);

                if (ApplicationLogic.IsValid(inputArray))
                {
                    // get base courses
                    bool hasSimpleBaseItmes = ApplicationLogic.HasSimpleBaseItems(inputArray);
                    if (hasSimpleBaseItmes)
                        Console.WriteLine(ApplicationLogic.OrderCoursesByPrerequisites(inputArray, new List<string> { "" }, new StringBuilder()));
                    else
                    {
                        string baseItems = ApplicationLogic.GetBaseItems(inputArray);
                        if (baseItems == "Circular Reference!")
                            Console.WriteLine(baseItems);
                        else
                        {
                            // get base items from string
                            string[] baseParts = baseItems.Split(':');
                            string[] outputBaseArray = baseParts[0].Split(new string[] { ", " }, StringSplitOptions.None);
                            List<string> prereqList = new List<string>();
                            foreach (string item in outputBaseArray)
                                prereqList.Add(item);
                            StringBuilder outputBase = new StringBuilder();
                            foreach (string item in outputBaseArray)
                                outputBase.Append(item + ", ");
                            Console.WriteLine(ApplicationLogic.OrderCoursesByPrerequisites(inputArray, prereqList, outputBase));
                        }
                    }
                }
                else
                    Console.WriteLine("Invalid Input!");
                Console.WriteLine("\nEnter courses below or type exit to quit:");
            }
        }

    }

    public static class ApplicationLogic
    {
        private static int count = 0;

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

        public static bool HasSimpleBaseItems(string[] inputArray)
        {
            foreach (string item in inputArray)
            {
                string[] courseInfo = item.Split(new string[] { ": " }, StringSplitOptions.None);
                if (courseInfo[1] == "") return true;

            }
            return false;
        }

        // In case base items were omitted, find any prereqs that don't match up to next level courses
        public static string GetBaseItems(string[] inputArray)
        {
            List<string> baseCourseList = new List<string>();
            List<string> prereqsList = new List<string>();
            StringBuilder baseCourses = new StringBuilder();
            StringBuilder secondLevel = new StringBuilder();

            foreach (string item in inputArray)
            {
                string[] courseInfo = item.Split(new string[] { ": " }, StringSplitOptions.None);
                baseCourseList.Add(courseInfo[0]);
                prereqsList.Add(courseInfo[1]);
            }
            for (int i = 0; i < prereqsList.Count; i++)
            {
                if (!baseCourseList.Contains(prereqsList[i]))
                {
                    baseCourses.Append(prereqsList[i] + ", ");
                    secondLevel.Append(baseCourseList[i] + ", ");
                }
            }
            if (baseCourses.Length == 0) return "Circular Reference!";
            baseCourses.Remove(baseCourses.Length - 2, 2);
            secondLevel.Remove(secondLevel.Length - 2, 2);

            // if the two lists match (and nothing was appended to baseCourses, there must be a circular reference
            return baseCourses.ToString() + ":" + secondLevel.ToString(); ;
        }

        public static string OrderCoursesByPrerequisites(string[] inputArray, List<string> prerequisites, StringBuilder output)
        {
            count++;
            List<string> prereqList = new List<string>();

            // loop through each item in list looking for prerequisites
            foreach (string item in inputArray)
            {
                string[] courseInfo = item.Split(new string[] { ": " }, StringSplitOptions.None);
                if (prerequisites.Contains(courseInfo[1]))
                {
                    prereqList.Add(courseInfo[0]);
                    output.Append(courseInfo[0] + ", ");
                }
            }

            // exit if caught in loop
            if (count > inputArray.Length + 1) return "Circular Reference!";

            // check to see if any of the added items are prerequisites for any other courses
            if (prereqList.Count > 0)
                OrderCoursesByPrerequisites(inputArray, prereqList, output);
            else  // clean up output string
                output.Remove(output.Length - 2, 2);

            return output.ToString();
        }
    }
}
