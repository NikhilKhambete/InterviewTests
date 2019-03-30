using System;

namespace GraduationTracker.Interfaces
{
    public interface IDiploma
    {
        int Id { get; set; }
        int Credits { get; set; }
        int[] Requirements { get; set; }
    }
}
