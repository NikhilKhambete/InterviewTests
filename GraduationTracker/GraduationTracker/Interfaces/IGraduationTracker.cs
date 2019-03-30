using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interfaces
{
    public interface IGraduationTracker
    {
        Tuple<bool, STANDING> HasGraduated(IDiploma diploma, IStudent student);

        STANDING GetStanding(int average);

    }
}
