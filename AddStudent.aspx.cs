using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab7
{
    public partial class Registration : System.Web.UI.Page
    {
        public List<Student> students = new List<Student>();
        protected void Page_Load(object sender, EventArgs e)
        {

            Debug.WriteLine("Page_Load method is executed.");

            //if (!IsPostBack)
            //{
                if (Session["students"] != null)
                {
                    students = (List<Student>)Session["students"];
                    //Display_Student();

                }
                //Display_Student();
            //}
            Display_Student();
        }

        protected void Add_Student(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtName.Text) || ddlType.SelectedValue == "Select")
            {
                return;
            } else if (string.IsNullOrEmpty(txtName.Text) || ddlType.SelectedValue == "full")
            {
                FulltimeStudent student = new FulltimeStudent(txtName.Text);
                student.Type = ddlType.SelectedValue;
                students.Add(student);
            } else if (string.IsNullOrEmpty(txtName.Text) || ddlType.SelectedValue == "part")
            {
                ParttimeStudent student = new ParttimeStudent(txtName.Text);
                student.Type = ddlType.SelectedValue;
                students.Add(student);
            } else if (string.IsNullOrEmpty(txtName.Text) || ddlType.SelectedValue == "co-op")
            {
                CoopStudent student = new CoopStudent(txtName.Text);
                student.Type = ddlType.SelectedValue;
                students.Add(student);
            }

                Session["students"] = students;
                Display_Student();

                txtName.Text = "";
                ddlType.SelectedIndex = 0;


        }



        protected void Display_Student()
        {
            tblDetails.Rows.Clear(); // This is not necessary, as the table will be recreated automatically

            TableHeaderRow tableHeaderRow = new TableHeaderRow();
            TableHeaderCell idHeaderCell = new TableHeaderCell();
            idHeaderCell.Text = "ID";
            tableHeaderRow.Cells.Add(idHeaderCell);

            TableHeaderCell nameHeaderCell = new TableHeaderCell();
            nameHeaderCell.Text = "Name";
            tableHeaderRow.Cells.Add(nameHeaderCell);

            tblDetails.Rows.Add(tableHeaderRow);
            if (students.Count > 0)
            {
                foreach (Student student in students)
                {
                    TableRow tableRow = new TableRow();
                    TableCell idCell = new TableCell();
                    TableCell nameCell = new TableCell();
                    idCell.Text = student.Id.ToString();
                    nameCell.Text = student.Name.ToString();
                    tableRow.Cells.Add(idCell);
                    tableRow.Cells.Add(nameCell);

                    tblDetails.Rows.Add(tableRow);
                }
            }
            else
            {
                TableRow tableRow = new TableRow();
                TableCell emptyCell = new TableCell();
                emptyCell.Text = "No Students Yet!";
                emptyCell.ColumnSpan = 2;
                tableRow.Cells.Add(emptyCell);

                tblDetails.Rows.Add(tableRow);
            }
        }

    }
}