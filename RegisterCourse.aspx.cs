using Lab6.Models;
using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Alert.Visible = false;
            Alert.InnerText = string.Empty;
            message.Visible = true;

            if (!IsPostBack)
            {
                List<Student> students = Session["Students"] as List<Student>;

                if (students != null)
                {
                    foreach (var student in students)
                    {
                        ddlStudents.Items.Add(new ListItem(student.ToString()));
                    }
                }

                foreach (Course c in Helper.GetAvailableCourses())
                {
                    cblCourse.Items.Add(new ListItem($"{c.Title} - {c.WeeklyHours} hours/week"));
                }
            }
        }

        protected bool Validate_Selection()
        {
            List<Student> students = Session["Students"] as List<Student>;


            Alert.InnerHtml = string.Empty;

            string selectedStudentName = ddlStudents.SelectedValue;

            Student selectedStudent = students.FirstOrDefault(s => s.ToString() == selectedStudentName);

            if (selectedStudent != null)
            {
                try
                {
                    List<Course> selectedCourses = Helper.GetAvailableCourses()
                        .Where(c => cblCourse.Items.FindByText($"{c.Title} - {c.WeeklyHours} hours/week").Selected)
                        .ToList();

                    selectedStudent.RegisterCourses(selectedCourses);

                    message.Visible = true;
                    message.InnerText = $"Selected student has registered {selectedStudent.RegisterCourse.Count} course(s), {selectedStudent.TotalWeeklyHours()} hours weekly";
                }
                catch (Exception ex)
                {
                    cblCourse.CssClass += " is-invalid";
                    Alert.InnerHtml += $"<p>Error occurred during registration: {ex.Message}</p>";
                    Alert.Visible = true;
                    message.Visible = false;
                    return false;
                }
            }
            else
            {
                Alert.InnerHtml += "<p>Selected student not found.</p>";
                Alert.Visible = true;
                message.Visible = false;
                return false;
            }

            return true;
        }







        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            Validate_Selection();
        }
    }
}
