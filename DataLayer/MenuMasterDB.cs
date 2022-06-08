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
   public class MenuMasterDB
   {
       public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

       public static void Add(MenuMaster menumaster)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand("Usp_MenuMaster_Insert", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Id", menumaster.Id);
           cmd.Parameters.AddWithValue("@Name", menumaster.Name);
           cmd.Parameters.AddWithValue("@AddId", menumaster.AddId);
           cmd.Parameters.AddWithValue("@EditId", menumaster.EditId);
           cmd.Parameters.AddWithValue("@DeleteId", menumaster.DeleteId);
           cmd.Parameters.AddWithValue("@ExtraColumn", menumaster.ExtraColumn);
           cmd.Parameters.AddWithValue("@Status", menumaster.Status);
           cmd.Parameters.AddWithValue("@CreatedBy", menumaster.CreatedBy);
           cmd.Parameters.AddWithValue("@CreatedOn", menumaster.CreatedOn);
           cmd.Parameters.AddWithValue("@UpdatedBy", menumaster.UpdatedBy);
           cmd.Parameters.AddWithValue("@UpdatedOn", menumaster.UpdatedOn);
           con.Open();
           cmd.ExecuteNonQuery();
           con.Close();
       }

       public static void Update(MenuMaster menumaster)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand("Usp_MenuMaster_Update", con);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@Id", menumaster.Id);
           cmd.Parameters.AddWithValue("@Name", menumaster.Name);
           cmd.Parameters.AddWithValue("@AddId", menumaster.AddId);
           cmd.Parameters.AddWithValue("@EditId", menumaster.EditId);
           cmd.Parameters.AddWithValue("@DeleteId", menumaster.DeleteId);
           cmd.Parameters.AddWithValue("@ExtraColumn", menumaster.ExtraColumn);
           cmd.Parameters.AddWithValue("@Status", menumaster.Status);
           cmd.Parameters.AddWithValue("@CreatedBy", menumaster.CreatedBy);
           cmd.Parameters.AddWithValue("@CreatedOn", menumaster.CreatedOn);
           cmd.Parameters.AddWithValue("@UpdatedBy", menumaster.UpdatedBy);
           cmd.Parameters.AddWithValue("@UpdatedOn", menumaster.UpdatedOn);
           con.Open();
           cmd.ExecuteNonQuery();
           con.Close();
       }

       public static void Delete(MenuMaster menumaster)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_MenuMaster_Delete";
           cmd.Parameters.AddWithValue("@Id", menumaster.Id);
           cmd.Connection = con;
           cmd.Connection.Open();
           cmd.ExecuteNonQuery();
           cmd.Connection.Close();
       }

       public static List<MenuMaster> Search(string word, Guid UserId)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_MenuMaster_Search";
           cmd.Parameters.AddWithValue("@Name", word);
           cmd.Parameters.AddWithValue("@UserId", UserId);
           cmd.Connection = con;
           cmd.Connection.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           List<MenuMaster> EmailList = new List<MenuMaster>();
           while (reader.Read())
           {
               MenuMaster Obj = new MenuMaster(reader);
              EmailList.Add(Obj);
           }
           reader.Close();
           cmd.Connection.Close();
           return EmailList;
       }

       public static List<MenuMaster> GetAll(Guid UserId)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_MenuMaster_GetAll";
           cmd.Parameters.AddWithValue("@UserId", UserId);
           cmd.Connection = con;
           cmd.Connection.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           List<MenuMaster> EmailList = new List<MenuMaster>();
           while (reader.Read())
           {
               MenuMaster Obj = new MenuMaster(reader);
               Obj.AddRecord = DBNull.Value != reader["AddRecord"] ? (string)reader["AddRecord"] : default(string);
               Obj.EditRecord = DBNull.Value != reader["EditRecord"] ? (string)reader["EditRecord"] : default(string);
               Obj.DeleteRecord = DBNull.Value != reader["DeleteRecord"] ? (string)reader["DeleteRecord"] : default(string);
               Obj.ViewRecord = DBNull.Value != reader["ViewRecord"] ? (string)reader["ViewRecord"] : default(string);
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
           SqlCommand cmd = new SqlCommand("Usp_MenuMaster_GetAll", con);
           cmd.CommandType = CommandType.StoredProcedure;
           SqlDataAdapter sda = new SqlDataAdapter(cmd);
           sda.Fill(ds);
           return ds;
       }

       public static MenuMaster GetById(Guid Id)
       {
           SqlConnection con = new SqlConnection(connection);
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "Usp_MenuMaster_GetById";
           cmd.Parameters.AddWithValue("@Id", Id);
           cmd.Connection = con;
           cmd.Connection.Open();
           SqlDataReader reader = cmd.ExecuteReader();
           MenuMaster menumaster = null;
           while (reader.Read())
           {
               menumaster = new MenuMaster(reader);
           }
           reader.Close();
           cmd.Connection.Close();
           return menumaster;
       }
   }
}



