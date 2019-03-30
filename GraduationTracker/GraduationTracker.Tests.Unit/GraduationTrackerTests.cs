using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Interfaces;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {

        static IGraduationTracker tracker = new GraduationTracker();
        static IDiploma diploma;
        static IStudent[] allStudents;

        public TestContext TestContext { get; set; }

        /// <summary>
        /// Logs TestName to The console
        /// </summary>
        [TestInitialize]
        public void LogTests()
        {
            Console.WriteLine("TestContext.TestName = '{0}'", TestContext.TestName);
        }

        /// <summary>
        /// Initializes the Class Level Static Variables for Referencing it throughout the class
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            tracker = new GraduationTracker();

            diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            allStudents = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            }
          };
        }

        /// <summary>
        /// Clean up the class level variables
        /// </summary>
        [ClassCleanup]
        public static void TestClean()
        {
            tracker = null;
            diploma = null;
            allStudents = null;
        }

        /// <summary>
        /// Verify if anyone graduated by removing the ones from the list who have diploma = false
        /// </summary>
        [TestMethod]
        public void TestHasGraduated()
        {
            var graduated = new List<Tuple<bool, STANDING>>();

            foreach(var student in allStudents)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));      
            }

            graduated = graduated.Where(x => x.Item1 == true).ToList();

            Assert.AreEqual(bool.TrueString.ToUpper(), graduated.Any().ToString().ToUpper());

        }

        /// <summary>
        /// Verify if anyone has not graduated by removing the ones from the list who have diploma = true
        /// Based on the mock data there is one student who has diploma = false
        /// </summary>
        [TestMethod]
        public void TestHasNotGraduated()
        {
            var graduated = new List<Tuple<bool, STANDING>>();

            graduated.Add(tracker.HasGraduated(diploma, allStudents[3]));

            graduated = graduated.Where(x => x.Item1 == false).ToList();

            Assert.AreEqual(bool.TrueString.ToUpper(), graduated.Any().ToString().ToUpper());
        }

        /// <summary>
        /// Test the return values from the GetStanding Method
        /// </summary>
        [TestMethod]
        public void TestGetStanding()
        {
            STANDING standing;

            standing = tracker.GetStanding(30);
            Assert.AreEqual("REMEDIAL", Convert.ToString(standing).ToUpper());

            standing = tracker.GetStanding(55);
            Assert.AreEqual("AVERAGE", Convert.ToString(standing).ToUpper());

            standing = tracker.GetStanding(85);
            Assert.AreEqual("SUMACUMLAUDE", Convert.ToString(standing).ToUpper());

            standing = tracker.GetStanding(100);
            Assert.AreEqual("MAGNACUMLAUDE", Convert.ToString(standing).ToUpper());
        }
    }
}
