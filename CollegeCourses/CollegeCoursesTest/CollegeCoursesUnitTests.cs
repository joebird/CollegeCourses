﻿using CollegeCourses;
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
        public void TestMultiplePrerequisiteOutput()
        {
            string[] inputArray = new string[] { "c: b", "b: a", "a: d" };
            Assert.AreEqual(ApplicationLogic.GetInputsAndOrderCourses(inputArray), "d, a, b, c");
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
            Assert.AreEqual(ApplicationLogic.GetInputsAndOrderCourses(inputArray), "Circular Reference!");
        }

        [TestMethod]
        public void TestComplexPrerequisitesOutput()
        {
            string[] inputArray = ApplicationLogic.courses;
            Assert.AreEqual(ApplicationLogic.OrderCoursesByPrerequisites(inputArray, new List<string> { "" }, new StringBuilder()), "Introduction to Paper Airplanes, " +
                "Rubber Band Catapults 101, Advanced Throwing Techniques, History of Cubicle Siege Engines, Paper Jet Engines, Advanced Office Warfare");
        }

        [TestMethod]
        public void TestHasSimpleBaseItems()
        {
            string[] inputArray = new string[] { "c: b", "b: a", "a: d" };
            Assert.IsFalse(ApplicationLogic.HasSimpleBaseItems(inputArray));
            inputArray = new string[] { "c: b", "b: a", "a: d", "d: " };
            Assert.IsTrue(ApplicationLogic.HasSimpleBaseItems(inputArray));
        }

        [TestMethod]
        public void TestGetBaseItems()
        {
            string[] inputArray = new string[] { "c: b", "x: y", "b: a", "w: x", "a: d" };
            Assert.AreEqual(ApplicationLogic.GetBaseItems(inputArray), "y, d:x, a");
        }
    }
}
