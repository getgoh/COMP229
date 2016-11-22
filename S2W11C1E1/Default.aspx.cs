using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        SqlConnection conn;
        DataSet dataSet = new DataSet();
        SqlDataAdapter adapter;

        string connectionString = ConfigurationManager.ConnectionStrings["DorknozzleConnectionString"].ConnectionString;

        if (ViewState["DZDS"] == null)
        {
            conn = new SqlConnection(connectionString);

            try
            {
                string query = "select DepartmentId, Department from Departments";

                adapter = new SqlDataAdapter(query, conn);

                adapter.Fill(dataSet, "Departments");

                query = "select EmployeeID, Name from Employees";

                adapter.SelectCommand.CommandText = query;

                adapter.Fill(dataSet, "Employees");
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }

            ViewState["DZDS"] = dataSet;
        }
        else
        {
            try
            {
                dataSet = (DataSet)ViewState["DZDS"];
            }
            catch(Exception e)
            {

            }            
        }

        string sortExpression;
        if (gridSortDirection == SortDirection.Ascending)
        {
            sortExpression = gridSortExpression + " ASC";
        }
        else
        {
            sortExpression = gridSortExpression + " DESC";
        }
        // Sort the data
        dataSet.Tables["Employees"].DefaultView.Sort = sortExpression;

        gvDepartments.DataSource = dataSet;
        gvDepartments.DataBind();
        gvEmployees.DataSource = dataSet.Tables["Employees"];
        gvEmployees.DataBind();

        gvEmployees.AllowPaging = true;
    }

    private SortDirection gridSortDirection
    {
        get
        {
            // Initial state is Ascending
            if (ViewState["GridSortDirection"] == null)
            {
                ViewState["GridSortDirection"] = SortDirection.Ascending;
            }
            // Return the state
            return (SortDirection)ViewState["GridSortDirection"];
        }
        set
        {
            ViewState["GridSortDirection"] = value;
        }
    }

    private string gridSortExpression
    {
        get
        {
            // Initial sort expression is DepartmentID
            if (ViewState["GridSortExpression"] == null)
            {
                ViewState["GridSortExpression"] = "EmployeeID";
            }
            // Return the sort expression
            return (string)ViewState["GridSortExpression"];
        }
        set
        {
            ViewState["GridSortExpression"] = value;
        }
    }

    protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // Retrieve the new page index
        int newPageIndex = e.NewPageIndex;
        // Set the new page index of the GridView
        gvEmployees.PageIndex = newPageIndex;
        // Bind the grid to its data source again to update its
        // contents
        BindGrid();
    }

    protected void gvEmployees_Sorting(object sender, GridViewSortEventArgs e)
    {
        // Retrieve the name of the clicked column (sort expression)
        string sortExpression = e.SortExpression;
        // Decide and save the new sort direction
        if (sortExpression == gridSortExpression)
        {
            if (gridSortDirection == SortDirection.Ascending)
            {
                gridSortDirection = SortDirection.Descending;
            }
            else
            {
                gridSortDirection = SortDirection.Ascending;
            }
        }
        else
        {
            gridSortDirection = SortDirection.Ascending;
        }
        // Save the new sort expression
        gridSortExpression = sortExpression;
        // Rebind the grid to its data source
        BindGrid();
    }

    protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gvEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataTable dt = ((DataSet)ViewState["DNDS"]).Tables["Employees"];
    }
}