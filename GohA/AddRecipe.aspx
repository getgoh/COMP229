<%-- Al Roben Adriane Goh - 300910584--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeFile="AddRecipe.aspx.cs" Inherits="Assignment1.AddRecipe" %>

<%@ Register Src="~/WUCIngredients.ascx" TagPrefix="uc1" TagName="WUCIngredients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add a Recipe Page</h1>
    <h3>In this page, you can add a new recipe</h3>

    <div class="dvFormHolder">
        
        <div class="buttonsHolder">
            <asp:Button ID="btnSubmit" Width="150" Height="40" Font-Size="Medium" Text="Save" runat="server" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnCancel" Width="150" Height="40" Font-Size="Medium" Text="Cancel" runat="server" OnClick="btnCancel_Click" CausesValidation="False" />
            <asp:Button ID="btnAddIngredient" CssClass="lm30" Width="150" Height="40" Font-Size="Medium" Text="Add Ingredient" runat="server" CausesValidation="False" OnClick="btnAddIngredient_Click" UseSubmitBehavior="False" />
            
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
                <%--<uc1:WUCIngredients runat="server" ID="wucIngredient1" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient2" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient3" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient4" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient5" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient6" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient7" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient8" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient9" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient10" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient11" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient12" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient13" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient14" />
                <uc1:WUCIngredients runat="server" ID="wucIngredient15" />--%>
            </div>
        </div>
    </div>
</asp:Content>

<%-- Al Roben Adriane Goh - 300910584--%>