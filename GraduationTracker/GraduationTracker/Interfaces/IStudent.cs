using System;

namespace GraduationTracker.Interfaces
{
    public interface IStudent
    {
        int Id { get; set; }
        Course[] Courses { get; set; }
        STANDING Standing { get; set; }
    }
}
