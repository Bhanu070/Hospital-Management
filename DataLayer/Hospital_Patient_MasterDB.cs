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
   
  public   class Patient_MasterDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        public static void Add(Patient_Master artype)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Patient_Master_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Patient_Id", artype.Patient_Id);               
                cmd.Parameters.AddWithValue("@Patient_Name", artype.Patient_Name);
                cmd.Parameters.AddWithValue("@Patient_UID", artype.Patient_UID);
                cmd.Parameters.AddWithValue("@Age", artype.Age);
                cmd.Parameters.AddWithValue("@Sex", artype.Sex);
                cmd.Parameters.AddWithValue("@MobileNo", artype.MobileNo);
                cmd.Parameters.AddWithValue("@Address", artype.Address);
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
        public static void Update(Patient_Master artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Patient_Master_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Patient_Id", artype.Patient_Id);
            cmd.Parameters.AddWithValue("@Patient_Name", artype.Patient_Name);
            cmd.Parameters.AddWithValue("@Patient_UID", artype.Patient_UID);
            cmd.Parameters.AddWithValue("@Age", artype.Age);
            cmd.Parameters.AddWithValue("@Sex", artype.Sex);
            cmd.Parameters.AddWithValue("@MobileNo", artype.MobileNo);
            cmd.Parameters.AddWithValue("@Address", artype.Address);
            cmd.Parameters.AddWithValue("@CreatedBy", artype.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", artype.UpdatedBy);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<Patient_Master> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Patient_Master_GetAll"; 
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Patient_Master> area = new List<Patient_Master>();
            while (reader.Read())
            {
                Patient_Master obj = new Patient_Master(reader);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;  
        }
        public static void Delete(Patient_Master  artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Patient_Master_Delete";
            cmd.Parameters.AddWithValue("@Patient_Id", artype.Patient_Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static Patient_Master GetById(Guid Patient_Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Patient_Master_GetById";
            cmd.Parameters.AddWithValue("@Patient_Id", Patient_Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Patient_Master Patient_Master = null;
            while (reader.Read())
            {
                Patient_Master = new Patient_Master(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return Patient_Master;
        }
    }
}
