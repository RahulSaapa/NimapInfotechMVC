using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NimapInfotechMVC.Models;

namespace NimapInfotechMVC.Repository
{
    public class CategoryRepo
    {
        public bool DeleteCategory(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SpDeleteCategory", sqlConnection);
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CId", id);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;

        }


        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SpGetCategory", sqlConnection);
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Category category = new Category();

                category.CId = Convert.ToInt32(sqlDataReader["CId"]);
                category.CategoryName = Convert.ToString(sqlDataReader["CategoryName"]);
                categories.Add(category);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
            return categories;
        }


        //public List<Category> GetCategory()
        //{
        //List<Category> productLists = new List<Category>();
        //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
        //SqlConnection sqlConnection = new SqlConnection(connectionString);
        //SqlCommand cmd = new SqlCommand("SpGetCategory", sqlConnection);
        //sqlConnection.Open();
        //cmd.CommandType = CommandType.StoredProcedure;
        //SqlDataReader sqlDataReader = cmd.ExecuteReader();
        //while (sqlDataReader.Read())
        //{
        //    Category product = new Category();
        //    product.CId = Convert.ToInt32(sqlDataReader["CId"]);
        //    product.CategoryName = Convert.ToString(sqlDataReader["CategoryName"]);
        //    productLists.Add(product);
        //}
        //sqlDataReader.Close();
        //sqlConnection.Close();
        //    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
        //    SqlConnection _con = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand("select * from Category", _con)
        //    SqlDataAdapter _da = new SqlDataAdapter(cmd);
        //    DataTable _dt = new DataTable();
        //    _da.Fill(_dt);
        //    ViewBag.CityList = ToSelectList(_dt, "CId", "CategoryName");

        //    return _da;

        //}

        public bool InsertCategory(Category category)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SpInsertCategory", sqlConnection);
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        public bool UpdateCategory(Category category)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SpUpdateCategory", sqlConnection);
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CId", category.CId);
            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        public Category GetCategorybyId(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SpGetCategoryById", sqlConnection);
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CId", id);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Category category = new Category();
            while (sqlDataReader.Read())
            {
                category.CId = Convert.ToInt32(sqlDataReader["CId"]);
                category.CategoryName = Convert.ToString(sqlDataReader["CategoryName"]);

            }
            sqlDataReader.Close();
            sqlConnection.Close();
            return category;
        }
    }
}