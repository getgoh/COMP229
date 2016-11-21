// Al Roben Adriane Goh - 300910584

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecipeDetails : System.Web.UI.Page
{
    int currRecipeId;

    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = Application["CurrentTheme"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        currRecipeId = int.Parse(Request.QueryString["recipeID"]);

        Recipe currRecipe = new DataManager().getRecipeById(currRecipeId);

        if (currRecipe == null)
            return;

        txtName.Text = currRecipe.Name;
        txtSubmitted.Text = currRecipe.SubmittedBy;
        txtCategory.Text = currRecipe.Category;
        txtCookingTime.Text = currRecipe.CookingTime.ToString();
        txtDescription.Text = currRecipe.Description;
        txtServings.Text = currRecipe.Servings.ToString();

        // Al Roben Adriane Goh - 300910584

        foreach (Ingredient i in currRecipe.IngredientList)
        {
            Control tempControl = LoadControl("WUCIngredients.ascx");
            ((WUCIngredients)tempControl)._txtName.ID = "ingName" + i.Id;
            ((WUCIngredients)tempControl)._txtName.Text = i.Name;

            ((WUCIngredients)tempControl)._txtQuantity.ID = "ingQuantity" + i.Id;
            ((WUCIngredients)tempControl)._txtQuantity.Text = i.Quantity.ToString();

            ((WUCIngredients)tempControl)._txtUnit.ID = "ingUnit" + i.Id;
            ((WUCIngredients)tempControl)._txtUnit.Text = i.Unit;

            phIngredients.Controls.Add(tempControl);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        new DataManager().deleteRecipeById(currRecipeId);
        Response.Redirect("Success.aspx?type=delete");
    }
}

// Al Roben Adriane Goh - 300910584