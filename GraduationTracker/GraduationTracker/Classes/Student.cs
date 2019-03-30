using System;
using GraduationTracker.Interfaces;

namespace GraduationTracker
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public STANDING Standing { get; set; } = STANDING.None;
    }
}
