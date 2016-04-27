using CollegeCourses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

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
        public void TestNoPrerequisitesOutput()
        {
            string[] inputArray = new string[] { "a: ", "b: " };
            Assert.AreEqual(ApplicationLogic.OrderCoursesByPrerequisites(inputArray, new List<string> { "" }, new StringBuilder()), "a, b");
        }

        [TestMethod]
        public void TestSimplePrerequisiteOutput()
        {
            string[] inputArray = new string[] { "a: ", "b: a" };
            Assert.AreEqual(ApplicationLogic.OrderCoursesByPrerequisites(inputArray, new List<string> { "" }, new StringBuilder()), "a, b");
        }

        [TestMethod]
        public void TestMediumComplexityPrerequisitesOutput()
        {
            string[] inputArray = new string[] { "a: ", "c: d", "b: a", "d: " };
            Assert.AreEqual(ApplicationLogic.OrderCoursesByPrerequisites(inputArray, new List<string> { "" }, new StringBuilder()), "a, d, c, b");
        }

        [TestMethod]
        public void TestCircularReferenceOutput()
        {
            string[] inputArray = new string[] { "a: b", "b: a" };
            Assert.AreEqual(ApplicationLogic.OrderCoursesByPrerequisites(inputArray, new List<string> { "" }, new StringBuilder()), "a, b");
        }

    }
}
