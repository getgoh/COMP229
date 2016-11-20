using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class Recipes : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = Application["CurrentTheme"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<Recipe> RecipeList = (List<Recipe>)Application["RecipeList"];
            List<Recipe> RecipeList = new DataManager().getRecipeList();

            foreach (Recipe recipe in RecipeList)
            {
                Control tempControl = LoadControl("WUCRecipe.ascx");
                ((WUCRecipe)tempControl).Name = recipe.Name;
                ((WUCRecipe)tempControl).SubmittedBy = recipe.SubmittedBy;
                ((WUCRecipe)tempControl).PrepareTime = recipe.CookingTime;
                phRecipes.Controls.Add(tempControl);
            }
        }
    }
}