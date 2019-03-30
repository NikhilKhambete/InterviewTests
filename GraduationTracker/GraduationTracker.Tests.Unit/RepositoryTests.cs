using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraduationTracker.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void GetStudentsTest()
        {
            IStudent student = Repository.GetStudent(1);
            ICourse course = student.Courses.ElementAt(0);
            int studentID = student.Id;
            int courseMark = course.Mark;
            string courseName = course.Name;
            int courseId = course.Id;

            Assert.AreEqual(1, studentID);
            Assert.AreEqual(1, courseId);
            Assert.AreEqual("Math", courseName);
            Assert.AreEqual(95, courseMark);
        }

        [TestMethod]
        public void GetDiplomaTest()
        {
            IDiploma diploma = Repository.GetDiploma(1);
            int diplomaID = diploma.Id;
            int diplomaCredits = diploma.Credits;
            int[] requirements = diploma.Requirements;

            Assert.AreEqual(1, diplomaID);
            Assert.AreEqual(4, diplomaCredits);
            Assert.AreEqual(100, requirements.ElementAt(0));
        }

        [TestMethod]
        public void GetRequirementTest()
        {
            IRequirement requirement = Repository.GetRequirement(102);
            int id = requirement.Id;
            string name = requirement.Name;
            int credits = requirement.Credits;
            int minimumMarks = requirement.MinimumMark;
            int[] courses = requirement.Courses;

            Assert.AreEqual(102, id);
            Assert.AreEqual("Science", name);
            Assert.AreEqual(1, credits);
            Assert.AreEqual(50, minimumMarks);
            Assert.AreEqual(2, courses.ElementAt(0));
        }
    }
}
