<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvDepartments" runat="server">
        </asp:GridView>

        <br /><br />

        <asp:GridView ID="gvEmployees" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateEditButton="True" OnPageIndexChanging="gvEmployees_PageIndexChanging" OnSorting="gvEmployees_Sorting" PageSize="3" OnRowEditing="gvEmployees_RowEditing" OnRowUpdating="gvEmployees_RowUpdating">
            <%--<Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>--%>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
