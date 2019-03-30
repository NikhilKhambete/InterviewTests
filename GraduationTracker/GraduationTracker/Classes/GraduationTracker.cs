using System;
using GraduationTracker.Interfaces;
namespace GraduationTracker
{
    public partial class GraduationTracker : IGraduationTracker
    {   
        public Tuple<bool, STANDING>  HasGraduated(IDiploma diploma, IStudent student)
        {
            var credits = 0;
            var average = 0;
        
            for(int i = 0; i < diploma.Requirements.Length; i++)
            {
                for(int j = 0; j < student.Courses.Length; j++)
                {
                    var requirement = Repository.GetRequirement(diploma.Requirements[i]);

                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k].Equals(student.Courses[j].Id))
                        {
                            average += student.Courses[j].Mark;
                            if (student.Courses[j].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                                break;
                            }
                        }
                    }
                }
            }

            average = average / student.Courses.Length;

            var standing = GetStanding(average);

            switch (standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING>(false, standing);
                case STANDING.Average:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.SumaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);

                default:
                    return new Tuple<bool, STANDING>(false, standing);
            } 
        }

        /// <summary>
        /// Separate method so that the code can be tested
        /// </summary>
        /// <param name="average"></param>
        /// <returns></returns>
        public STANDING GetStanding(int average)
        {
            var standing = STANDING.None;

            if (average < 50)
                standing = STANDING.Remedial;
            else if (average >= 50 && average < 80)
                standing = STANDING.Average;
            else if (average >= 80 && average < 95)
                standing = STANDING.SumaCumLaude;
            else
                standing = STANDING.MagnaCumLaude;

            return standing;
        }
    }
}
