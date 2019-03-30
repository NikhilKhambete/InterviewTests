using System;

namespace GraduationTracker.Interfaces
{
    public interface IRequirement
    {
        int Id { get; set; }
        string Name { get; set; }
        int MinimumMark { get; set; }
        int Credits { get; set; }
        int[] Courses { get; set; }
    }
}
