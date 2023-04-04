using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NimapInfotechMVC.Models;

namespace NimapInfotechMVC.Repository
{
    public class ProductRepo
    {

        public bool DeleteProduct(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString); 
            SqlCommand cmd = new SqlCommand("SpDeleteProduct", sqlConnection);
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", id);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;

        }


        public List<ProductList> GetProducts()
        {
            List<ProductList> productLists = new List<ProductList>();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString); 
            SqlCommand cmd = new SqlCommand("SpGetProducts", sqlConnection); 
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ProductList product = new ProductList();

                product.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
                product.ProductName = Convert.ToString(sqlDataReader["ProductName"]);
                product.CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]);
                product.CategoryName = Convert.ToString(sqlDataReader["CategoryName"]);
                productLists.Add(product);
            }
            sqlDataReader.Close();
            sqlConnection.Close();
            return productLists;
        }


        public bool InsertProduct(Product product)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString); 
            SqlCommand cmd = new SqlCommand("SpInsertProduct", sqlConnection); 
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString); 
            SqlCommand cmd = new SqlCommand("SpUpdateProduct", sqlConnection); 
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        public Product GetProductbyId(int id)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Nimupinfotech"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString); 
            SqlCommand cmd = new SqlCommand("SpGetProductById", sqlConnection);
            sqlConnection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", id);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Product product = new Product();
            while (sqlDataReader.Read())
            {
                product.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
                product.ProductName = Convert.ToString(sqlDataReader["ProductName"]);
                product.CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]);

            }
            sqlDataReader.Close();
            sqlConnection.Close();
            return product;
        }
    }
}