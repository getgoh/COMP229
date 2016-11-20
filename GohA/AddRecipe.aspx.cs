using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class AddRecipe : System.Web.UI.Page
    {
        private List<Control> ingList;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = Application["CurrentTheme"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ingList = new List<Control>();
                initiateIngredientInputs(5);
                showIngredientInputs();
            }            
        }

        private void initiateIngredientInputs(int num)
        {
            for(int x = 1; x <= num; x++)
            {                
                Control tempControl = LoadControl("WUCIngredients.ascx");
                ((WUCIngredients)tempControl)._txtName.ID = "ingName" + x;
                ((WUCIngredients)tempControl)._txtQuantity.ID = "ingQuantity" + x;
                ((WUCIngredients)tempControl)._txtUnit.ID = "ingUnit" + x;
                ingList.Add(tempControl);
            }

            Session["ingList"] = ingList;
        }

        private void showIngredientInputs()
        {
            phIngredients.Controls.Clear();
            foreach (Control tempControl in ingList)
            {
                phIngredients.Controls.Add(tempControl);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            { 
                Recipe newRecipe = new Recipe()
                {
                    Name = txtName.Text,
                    SubmittedBy = txtSubmitted.Text,
                    Category = txtCategory.Text,
                    Servings = int.Parse(txtServings.Text),
                    CookingTime = int.Parse(txtCookingTime.Text),
                    Description = txtDescription.Text,
                    IngredientList = getIngredients()
                };

                // add to db..
                Response.Write("<script type='text/javascript'> alert('" + new DataManager().insertNewRecipe(newRecipe) + "'); </script>");

                //((List<Recipe>)Application["RecipeList"]).Add(newRecipe);

                //Response.Redirect("RecipeAdded.aspx");
            }
        }
        

        private List<Ingredient> getIngredients()
        {
            List<Ingredient> IngredientList = new List<Ingredient>();

            foreach(Control tempControl in phIngredients.Controls)
            {
                IngredientList.Add(new Ingredient() { Name = ((WUCIngredients)tempControl).Name, Quantity = ((WUCIngredients)tempControl).Quantity, Unit = ((WUCIngredients)tempControl).Unit });
            }

            //IngredientList.Add(new Ingredient() { Name = wucIngredient1.Name, Quantity = wucIngredient1.Quantity, Unit = wucIngredient1.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient2.Name, Quantity = wucIngredient2.Quantity, Unit = wucIngredient2.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient3.Name, Quantity = wucIngredient3.Quantity, Unit = wucIngredient3.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient4.Name, Quantity = wucIngredient4.Quantity, Unit = wucIngredient4.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient5.Name, Quantity = wucIngredient5.Quantity, Unit = wucIngredient5.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient6.Name, Quantity = wucIngredient6.Quantity, Unit = wucIngredient6.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient7.Name, Quantity = wucIngredient7.Quantity, Unit = wucIngredient7.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient8.Name, Quantity = wucIngredient8.Quantity, Unit = wucIngredient8.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient9.Name, Quantity = wucIngredient9.Quantity, Unit = wucIngredient9.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient10.Name, Quantity = wucIngredient10.Quantity, Unit = wucIngredient10.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient11.Name, Quantity = wucIngredient11.Quantity, Unit = wucIngredient11.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient12.Name, Quantity = wucIngredient12.Quantity, Unit = wucIngredient12.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient13.Name, Quantity = wucIngredient13.Quantity, Unit = wucIngredient13.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient14.Name, Quantity = wucIngredient14.Quantity, Unit = wucIngredient14.Unit });
            //IngredientList.Add(new Ingredient() { Name = wucIngredient15.Name, Quantity = wucIngredient15.Quantity, Unit = wucIngredient15.Unit });

            return IngredientList;
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnAddIngredient_Click(object sender, EventArgs e)
        {
            Control tempControl = LoadControl("WUCIngredients.ascx");
            ((WUCIngredients)tempControl)._txtName.ID = "ingName";
            ((WUCIngredients)tempControl)._txtQuantity.ID = "ingQuantity";
            ((WUCIngredients)tempControl)._txtUnit.ID = "ingUnit";

            ingList = (List<Control>)Session["ingList"];

            ingList.Add(tempControl);

            showIngredientInputs();
        }
    }
}