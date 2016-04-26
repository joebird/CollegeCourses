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
            string[] inputArray = new string[] { "a", "b", "c" };
            Assert.IsTrue(!IsValid(inputArray));
        }

        private bool IsValid(string[] inputArray)
        {
            return true;
        }
    }
}
