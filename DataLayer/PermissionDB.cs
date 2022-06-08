using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataLayer
{
    // Created By Javed Akhtar
   public  class PermissionDB:BaseObject
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(Permission permission)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Usp_Permission_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", permission.Id);
                cmd.Parameters.AddWithValue("@UserId", permission.UserId);
                cmd.Parameters.AddWithValue("@MenuName", permission.MenuName);
                cmd.Parameters.AddWithValue("@AddRecord", permission.AddRecord);
                cmd.Parameters.AddWithValue("@UpdateRecord", permission.UpdateRecord);
                cmd.Parameters.AddWithValue("@DeleteRecord", permission.DeleteRecord);
                cmd.Parameters.AddWithValue("@ExtraColumn", permission.ExtraColumn);
                cmd.Parameters.AddWithValue("@Status", permission.Status);

                cmd.Parameters.AddWithValue("@CreatedBy", permission.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedOn", permission.CreatedOn);
                cmd.Parameters.AddWithValue("@UpdatedBy", permission.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedOn", permission.UpdatedOn);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static void Update(Permission permission)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Permission_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", permission.Id);
            cmd.Parameters.AddWithValue("@UserId", permission.UserId);
            cmd.Parameters.AddWithValue("@MenuName", permission.MenuName);
            cmd.Parameters.AddWithValue("@AddRecord", permission.AddRecord);
            cmd.Parameters.AddWithValue("@UpdateRecord", permission.UpdateRecord);
            cmd.Parameters.AddWithValue("@DeleteRecord", permission.DeleteRecord);
            cmd.Parameters.AddWithValue("@ExtraColumn", permission.ExtraColumn);
            cmd.Parameters.AddWithValue("@Status", permission.Status);

            cmd.Parameters.AddWithValue("@CreatedBy", permission.CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedOn", permission.CreatedOn);
            cmd.Parameters.AddWithValue("@UpdatedBy", permission.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", permission.UpdatedOn);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<Permission> GetByUserId(Guid UserId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Permission_GetByUserId";
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Permission> Product = new List<Permission>();
            while (reader.Read())
            {
                Permission Obj = new Permission(reader);
                Product.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return Product;
        }

        public static List<Permission> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Permission_GetAll";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Permission> Product = new List<Permission>();
            while (reader.Read())
            {
                Permission Obj = new Permission(reader);
                Product.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return Product;
        }

        public static void Delete(Permission permission)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Permission_Delete";
            cmd.Parameters.AddWithValue("@Id", permission.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static Permission GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Permission_GetById";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Permission Permission = null;
            while (reader.Read())
            {
                Permission = new Permission(reader);
            }
            reader.Close();
            cmd.Connection.Close();

            return Permission;

        }

    }
}
