<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
<style>
        .h1font{
            font: Georgia, serif;
            border-bottom: 3px solid #cc9900;
            color: #996600;
        }
        body {
            font: "Trebuchet MS", Verdana, sans-serif;
            background-color: lightyellow;
            color: #696969;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="h1font" visible="false">Algonquin College Course Registration</h1>
        <div>
            <label for="ddlList">Student: </label>
            <asp:DropDownList ID="ddlStudents" runat="server" AppendDataBoundItems="true" >
                 <asp:ListItem Value="">-- Select Student --</asp:ListItem>
            </asp:DropDownList>
            <h1 id="message" runat="server"></h1>
            <asp:RequiredFieldValidator 
                ID="rfvStudents" 
                runat="server"
                ControlToValidate="ddlStudents"
                ErrorMessage="Please select a student from the list."
                CssClass="text-danger"
                Display="Dynamic"
                EnableClientScript="true"
                InitialValue="" />
                
        </div>
        <div class="mb-3">
            <div class="alert alert-danger" id="Alert" runat="server" visible="false"></div>
        </div>
        <div>
            <asp:CheckBoxList ID="cblCourse" runat="server" Visible="true"></asp:CheckBoxList>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSave_Click"/>
        <a href="AddStudent.aspx">Add students</a>
    </form>
</body>
</html>