using CollegeCourses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollegeCoursesTest
{
    [TestClass]
    public class CollegeCoursesUnitTests
    {
        [TestMethod]
        public void TestCourseNameHasProperFormat()
        {
            string[] inputArray = ApplicationLogic.courses;
            Assert.IsTrue(IsValid(inputArray));
        }

        [TestMethod]
        public void TestCourseNameHasImproperFormat()
        {
            string[] inputArray = new string[] { "a: ", "b:", "c" };
            Assert.IsFalse(IsValid(inputArray));
        }

        private bool IsValid(string[] inputArray)
        {
            // verify that each item in the array has a value followed by a colon followed by at least a space
            foreach (string item in inputArray)
            {
                // get location of colon
                int location = item.IndexOf(": ");
                if (location < 1) return false;
            }
            return true;
        }
    }
}
