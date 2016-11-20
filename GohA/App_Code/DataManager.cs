using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data;

/// <summary>
/// Summary description for DataManager
/// </summary>
public class DataManager
{
    private string connString = "DATA SOURCE=oracle1.centennialcollege.ca:1521/SQLD;USER ID=COMP214F16_004_P_39;PASSWORD=password";
    private OracleConnection conn;
    private OracleCommand cmd, ingCmd;
    private OracleDataReader reader;
    private string query = "";

    public DataManager()
    {
        conn = new OracleConnection(connString);
    }

    public int insertNewRecipe(Recipe newRecipe)
    {
        query = "RB_ADDRECIPE";

        conn.Open();

        cmd = new OracleCommand(query, conn);

        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.Add("NAME", OracleDbType.Varchar2).Value = newRecipe.Name;
        cmd.Parameters.Add("SUBMITTEDBY", OracleDbType.Varchar2).Value = newRecipe.SubmittedBy;
        cmd.Parameters.Add("CATEGORY", OracleDbType.Varchar2).Value = newRecipe.Category;
        cmd.Parameters.Add("COOKINGTIME", OracleDbType.Int32).Value = newRecipe.CookingTime;
        cmd.Parameters.Add("SERVINGS", OracleDbType.Int32).Value = newRecipe.Servings;
        cmd.Parameters.Add("DESCRIPTION", OracleDbType.Varchar2).Value = newRecipe.Description;

        cmd.Parameters.Add("NEWID", OracleDbType.Int32).Direction = ParameterDirection.Output;

        cmd.ExecuteNonQuery();

        int newId = newRecipe.Id = int.Parse(cmd.Parameters["NEWID"].Value.ToString());
        
        

        //cmd.ExecuteNonQuery();

        insertIngredients(newRecipe);

        conn.Close();

        return newId;
    }

    private int insertIngredients(Recipe newRecipe)
    {
        query = "RB_ADDINGREDIENT";
        
        foreach (Ingredient i in newRecipe.IngredientList)
        {
            cmd = new OracleCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("RECIPEID", OracleDbType.Int32).Value = newRecipe.Id;
            cmd.Parameters.Add("NAME", OracleDbType.Varchar2).Value = i.Name;
            cmd.Parameters.Add("QUANTITY", OracleDbType.Int32).Value = i.Quantity;
            cmd.Parameters.Add("MEASUREUNIT", OracleDbType.Varchar2).Value = i.Unit;

            cmd.ExecuteNonQuery();
        }

        return 0;
    }

    public List<Recipe> getRecipeList()
    {
        List<Recipe> RecipeList = new List<Recipe>();

        query = "select * from RB_RECIPE";

        conn.Open();

        cmd = new OracleCommand(query, conn);

        reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            Recipe r = new Recipe();
            r.Id = Convert.ToInt32(reader["RECIPEID"].ToString());
            r.Name = reader["NAME"].ToString();
            r.SubmittedBy = reader["SUBMITTEDBY"].ToString();
            r.Category = reader["CATEGORY"].ToString();
            r.CookingTime = Convert.ToInt32(reader["COOKINGTIME"].ToString());
            r.Servings = Convert.ToInt32(reader["SERVINGS"].ToString());
            r.Description = reader["DESCRIPTION"].ToString();

            r.IngredientList = getIngredientsByRecipeID(r.Id);

            RecipeList.Add(r);
        }

        conn.Close();

        return RecipeList;
    }

    private List<Ingredient> getIngredientsByRecipeID(int recipeId)
    {
        List<Ingredient> IngredientList = new List<Ingredient>();

        query = "select * from RB_INGREDIENT where RECIPEID=" + recipeId;

        // conn is already open at this point
        //conn.Open();

        ingCmd = new OracleCommand(query, conn);

        reader = cmd.ExecuteReader();

        if (reader == null || !reader.HasRows)
            return IngredientList;

        while(reader.Read())
        {
            Ingredient i = new Ingredient();
            //i.Id = Convert.ToInt32(reader["INGREDIENTID"].ToString());
            //i.Id = 234;
            //i.Name = reader["NAME"].ToString();
            //i.Quantity = Convert.ToInt32(reader["QUANTITY"].ToString());
            //i.Unit = reader["MEASUREUNIT"].ToString();

            IngredientList.Add(i);
        }

        return IngredientList;
    }

    public static string SafeGetString(OracleDataReader reader, int colIndex)
    {
        if (!reader.IsDBNull(colIndex))
            return reader.GetString(colIndex);
        return string.Empty;
    }

    private void testOracle()
    {
        string cityListQuery = "select * from bb_basket";

        conn.Open();

        cmd = new OracleCommand(cityListQuery, conn);

        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            //Response.Write(oreader[0].ToString() + "<br />");
            //Response.Write(oreader[1].ToString() + "<br />");
            //Response.Write(oreader[2].ToString() + "<br />");
            //Response.Write(oreader[0].ToString() + "<br />");
        }
        conn.Close();
    }
}