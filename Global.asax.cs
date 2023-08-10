using Lab7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Lab8
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            FulltimeStudent.MaxWeeklyHours = 16;
            ParttimeStudent.MaxNumOfCourses = 3;
            CoopStudent.MaxNumOfCourses = 2;
            CoopStudent.MaxWeeklyHours = 4;

            ScriptResourceDefinition RefDef = new ScriptResourceDefinition();
            RefDef.Path = "https://unpkg.com/jquery";
            RefDef.DebugPath = "https://unpkg.com/jquery";
            RefDef.CdnPath = "https://unpkg.com/jquery";
            RefDef.CdnDebugPath = "https://unpkg.com/jquery";

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, RefDef);
        }
    }
}