<%-- Al Roben Adriane Goh - 300910584--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeFile="RecipeDetails.aspx.cs" Inherits="RecipeDetails" %>

<%@ Register Src="~/WUCIngredients.ascx" TagPrefix="uc1" TagName="WUCIngredients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Recipe Details</h1>
    <h3>In this page, you can add a new recipe</h3>

    <div class="dvFormHolder">
        
        <div class="buttonsHolder">
            <asp:Button ID="btnDelete" Width="150" Height="40" Font-Size="Medium" Text="Delete Recipe" ForeColor="White" BackColor="Red" runat="server" OnClick="btnDelete_Click" />
        </div>
        <hr />
        <div>
            <div id="dvLeftSideHolder">
                <ul>
                    <li class="style-1">
                    
                        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter recipe name" ControlToValidate="txtName" ForeColor="Red" Display="Static"></asp:RequiredFieldValidator>
                    </li>
        
            
                    <li class="style-1">
                        <asp:Label ID="lblSubmitted" runat="server" Text="Submitted by: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtSubmitted" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter author name" ControlToValidate="txtSubmitted" ForeColor="Red" Display="Static"></asp:RequiredFieldValidator>
                    </li>
                    <li class="style-1">
                        <asp:Label ID="lblCategory" runat="server" Text="Category: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
                        <br />
                        <br />  
                    </li>

    <%-- Al Roben Adriane Goh - 300910584--%>
        
                    <li class="style-1">
                        <asp:Label ID="lblCookingTime" runat="server" Text="Prepare/cooking time: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCookingTime" TextMode="Number" runat="server"></asp:TextBox>
                        <br />
                        
                        <br />
                    </li>
        
                    <li class="style-1">
                        <asp:Label ID="lblServings" runat="server" Text="Number of Servings: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtServings" TextMode="Number" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter number of servings" ControlToValidate="txtServings" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    <li class="style-1">
                        <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="100px" Width="170px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter description" ControlToValidate="txtDescription" ForeColor="Red" Display="Static"></asp:RequiredFieldValidator>
                    </li>
                </ul>
            </div>
       
            <div id="dvRightSideHolder">
                <asp:Label Text="Ingredients:" runat="server" />
                <asp:PlaceHolder ID="phIngredients" runat="server" />  
            </div>
        </div>
    </div>
</asp:Content>



<%-- Al Roben Adriane Goh - 300910584--%>