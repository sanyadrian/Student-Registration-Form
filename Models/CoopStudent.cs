using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours {  get; set; }
        public static int MaxNumOfCourses { get; set; }
        public CoopStudent(string name) : base(name) 
        {

        }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            RegisterCourse.Clear();
            RegisterCourse.AddRange(selectedCourses);
            if (RegisterCourse.Count() < 1)
            {
                RegisterCourse.Clear();
                throw new Exception($" You need to select at least 1 course");
            }
            else if (TotalWeeklyHours() > MaxWeeklyHours && TotalWeeklyHours() > MaxNumOfCourses)
            {
                RegisterCourse.Clear();
                throw new Exception($" You cannot exceed more than {MaxWeeklyHours} hours");
            }
            else if (RegisterCourse.Count() > MaxNumOfCourses)
            {
                RegisterCourse.Clear();
                throw new Exception($" You cannot exceed more than {MaxNumOfCourses} courses");
            }

        }

        public override string ToString()
        {
            return $"{Id} - {Name} (CoOp)";
        }
    }
}