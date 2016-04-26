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
            Assert.IsTrue(ApplicationLogic.IsValid(inputArray));
        }

        [TestMethod]
        public void TestCourseNameHasImproperFormatMissingFinalSpace()
        {
            string[] inputArray = new string[] { "a:" };
            Assert.IsFalse(ApplicationLogic.IsValid(inputArray));
        }

        [TestMethod]
        public void TestCourseNameHasImproperFormatTwoColonSpaceCombos()
        {
            string[] inputArray = new string[] { "a: : " };
            Assert.IsFalse(ApplicationLogic.IsValid(inputArray));
        }

        [TestMethod]
        public void TestSimplePrerequisiteOutput()
        {
            string[] inputArray = new string[] { "a: ", "b: a" };
            Assert.AreSame(ApplicationLogic.OrderCoursesByPrerequisites(inputArray, ""), "a, b");
        }

    }
}
