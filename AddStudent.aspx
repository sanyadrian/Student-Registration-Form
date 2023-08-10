<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab7.Registration" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <link rel="stylesheet" href="App_Themes/Style.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <style>
        h1{
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
    
    <div>
        <form id="form1" runat="server">
            <h1>Students</h1>
            <div class="form-group row">
                <div>
                    <label for="txtName" class="col-sm-0 col-form-label">Student Name</label>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator 
                            ID="rfvtxtName" 
                            runat="server" 
                            ControlToValidate ="txtName"
                            CssClass="text-danger"
                            Display="Dynamic"
                            EnableClientScript="true">
                            Name is required!
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

            </div>

            <div class="from-group row">
                <label for="ddlType" class="fcol-sm-0 col-form-label">Student Type</label>
                <div class="col-sm-2">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control mb-3" AutoPostBack="true">
                        <asp:ListItem Value="Select">Select..</asp:ListItem>
                        <asp:ListItem Value="full">Full Time</asp:ListItem>
                        <asp:ListItem Value="part">Part Time</asp:ListItem>
                        <asp:ListItem Value="co-op">Co-op</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator 
                        ID="rfvddlType" 
                        runat="server" 
                        ControlToValidate="ddlType"
                        InitialValue="Select"
                        CssClass="text-danger"
                        Display="Dynamic"
                        EnableClientScript="true">
                        Course is required!
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Add_Student" CssClass="btn btn-transparent btn-outline-dark btn-block mb-3" />
        </form>
    </div>
    <div>
        <asp:Table ID="tblDetails" runat="server" CssClass="table table-striped w-50 p-3"></asp:Table>
    </div>
    <a href="RegisterCourse.aspx"> Register Courses</a>
</body>
</html>
