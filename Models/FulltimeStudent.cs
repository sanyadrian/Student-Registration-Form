using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours {  get; set; }
        public FulltimeStudent(string name) : base(name)
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
            else if (TotalWeeklyHours() > MaxWeeklyHours)
            {
                RegisterCourse.Clear();
                throw new Exception($" You cannot exceed more than {MaxWeeklyHours} hours");
            }

        }

        public override string ToString()
        {
            return $"{Id} - {Name} (Full Time)";
        }
    }
}