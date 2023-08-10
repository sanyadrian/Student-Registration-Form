using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public readonly List <Course> RegisterCourse = new List<Course> ();
        public Student(string name) 
        {
            Id = GenerateId();
            Name = name;

        }

        private int GenerateId() 
        { 
            Random rnd = new Random();
            return rnd.Next(100000, 1000000);
        }

        public virtual void RegisterCourses (List<Course> selectedCourses)
        {
            RegisterCourse.Clear();
            RegisterCourse.AddRange(selectedCourses);
        }

        public int TotalWeeklyHours()
        {
            int totalHours = 0;
            foreach (var course in RegisterCourse) 
            {
                totalHours += course.WeeklyHours;
            }
            return totalHours;
        }

        public virtual string ToString()
        {
            return $"{Id} - {Name} (student)";
        }

    }
}