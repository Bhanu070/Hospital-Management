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
   
  public   class Doctor_MasterDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        public static void Add(Doctor_Master artype)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Doctor_Master_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Doc_Id", artype.Doc_Id);               
                cmd.Parameters.AddWithValue("@Doc_Name", artype.Doc_Name);
                cmd.Parameters.AddWithValue("@Qualification", artype.Qualification);
                cmd.Parameters.AddWithValue("@CreatedBy", artype.CreatedBy);
                cmd.Parameters.AddWithValue("@UpdatedBy", artype.UpdatedBy);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void Update(Doctor_Master artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Doctor_Master_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Doc_Id", artype.Doc_Id);
            cmd.Parameters.AddWithValue("@Doc_Name", artype.Doc_Name);
            cmd.Parameters.AddWithValue("@Qualification", artype.Qualification);
            cmd.Parameters.AddWithValue("@CreatedBy", artype.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", artype.UpdatedBy);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<Doctor_Master> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Doctor_Master_GetAll"; 
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Doctor_Master> area = new List<Doctor_Master>();
            while (reader.Read())
            {
                Doctor_Master obj = new Doctor_Master(reader);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;  
        }
        public static void Delete(Doctor_Master  artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Doctor_Master_Delete";
            cmd.Parameters.AddWithValue("@Doc_Id", artype.Doc_Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static Doctor_Master GetById(Guid Doc_Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Doctor_Master_GetById";
            cmd.Parameters.AddWithValue("@Doc_Id", Doc_Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Doctor_Master Doctor_Master = null;
            while (reader.Read())
            {
                Doctor_Master = new Doctor_Master(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return Doctor_Master;
        }
    }
}
