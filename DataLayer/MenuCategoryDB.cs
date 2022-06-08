using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BusinessObject;

namespace DataLayer
{
    // Created By Javed Akhtar
   public class MenuCategoryDB
   {
       public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

       public static void Add(MenuCategory menucategory)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand("Usp_MenuCategory_Insert", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Id", menucategory.Id);
           cmd.Parameters.AddWithValue("@Name", menucategory.Name);
           cmd.Parameters.AddWithValue("@ExtraColumn", menucategory.ExtraColumn);
           cmd.Parameters.AddWithValue("@Status", menucategory.Status);
           cmd.Parameters.AddWithValue("@CreatedBy", menucategory.CreatedBy);
           cmd.Parameters.AddWithValue("@CreatedOn", menucategory.CreatedOn);
           cmd.Parameters.AddWithValue("@UpdatedBy", menucategory.UpdatedBy);
           cmd.Parameters.AddWithValue("@UpdatedOn", menucategory.UpdatedOn);
           con.Open();
           cmd.ExecuteNonQuery();
           con.Close();
       }

       public static void Update(MenuCategory menucategory)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand("Usp_MenuCategory_Update", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Id", menucategory.Id);
           cmd.Parameters.AddWithValue("@Name", menucategory.Name);
           cmd.Parameters.AddWithValue("@ExtraColumn", menucategory.ExtraColumn);
           cmd.Parameters.AddWithValue("@Status", menucategory.Status);
           cmd.Parameters.AddWithValue("@CreatedBy", menucategory.CreatedBy);
           cmd.Parameters.AddWithValue("@CreatedOn", menucategory.CreatedOn);
           cmd.Parameters.AddWithValue("@UpdatedBy", menucategory.UpdatedBy);
           cmd.Parameters.AddWithValue("@UpdatedOn", menucategory.UpdatedOn);
           con.Open();
           cmd.ExecuteNonQuery();
           con.Close();
       }

       public static void Delete(MenuCategory menucategory)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_MenuCategory_Delete";
           cmd.Parameters.AddWithValue("@Id", menucategory.Id);
           cmd.Connection = con;
           cmd.Connection.Open();
           cmd.ExecuteNonQuery();
           cmd.Connection.Close();
       }

       public static List<MenuCategory> Search(string word, Guid UserId)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_MenuCategory_Search";
           cmd.Parameters.AddWithValue("@Name", word);
           cmd.Parameters.AddWithValue("@UserId", UserId);
           cmd.Connection = con;
           cmd.Connection.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           List<MenuCategory> EmailList = new List<MenuCategory>();
           while (reader.Read())
           {
               MenuCategory Obj = new MenuCategory(reader);
              EmailList.Add(Obj);
           }
           reader.Close();
           cmd.Connection.Close();
           return EmailList;
       }

       public static List<MenuCategory> GetAll(Guid UserId)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_MenuCategory_GetAll";
           cmd.Parameters.AddWithValue("@UserId", UserId);
           cmd.Connection = con;
           cmd.Connection.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           List<MenuCategory> EmailList = new List<MenuCategory>();
           while (reader.Read())
           {
               MenuCategory Obj = new MenuCategory(reader);
               EmailList.Add(Obj);
           }
           reader.Close();
           cmd.Connection.Close();
           return EmailList;
       }

       public static DataSet getdataset()
       {
           SqlConnection con = new SqlConnection(connection);
           if (con.State == ConnectionState.Closed)
           {
               con.Open();
           }
           DataSet ds = new DataSet();
           SqlCommand cmd = new SqlCommand("Usp_MenuCategory_GetAll", con);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           sda.Fill(ds);
           return ds;
       }

       public static MenuCategory GetById(Guid Id)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_MenuCategory_GetById";
           cmd.Parameters.AddWithValue("@Id", Id);
           cmd.Connection = con;
           cmd.Connection.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           MenuCategory menucategory = null;
           while (reader.Read())
           {
               menucategory = new MenuCategory(reader);
           }
           reader.Close();
           cmd.Connection.Close();
           return menucategory;
       }
   }
}



