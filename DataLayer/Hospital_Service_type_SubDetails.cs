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
   
  public   class Service_type_SubDetailsDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        public static void Add(Service_type_SubDetails artype)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Service_type_SubDetails_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceId", artype.ServiceId);               
                cmd.Parameters.AddWithValue("@MainId", artype.MainId);
                cmd.Parameters.AddWithValue("@Price", artype.Price);
                cmd.Parameters.AddWithValue("@Discount", artype.Discount);
                cmd.Parameters.AddWithValue("@Unit", artype.Unit);
                cmd.Parameters.AddWithValue("@PaidAmount", artype.PaidAmount);
                cmd.Parameters.AddWithValue("@Status", artype.Status);
                cmd.Parameters.AddWithValue("@CreatedOn", artype.CreatedOn);
                cmd.Parameters.AddWithValue("@UpdatedOn", artype.UpdatedOn);
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
        public static void Add_temp(Service_type_SubDetails artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Service_type_SubDetails_temp_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ServiceId", artype.ServiceId);
            cmd.Parameters.AddWithValue("@MainId", artype.MainId);
            cmd.Parameters.AddWithValue("@Price", artype.Price);
            cmd.Parameters.AddWithValue("@Discount", artype.Discount);
            cmd.Parameters.AddWithValue("@Unit", artype.Unit);
            cmd.Parameters.AddWithValue("@PaidAmount", artype.PaidAmount);
            cmd.Parameters.AddWithValue("@Status", artype.Status);
            cmd.Parameters.AddWithValue("@CreatedOn", artype.CreatedOn);
            cmd.Parameters.AddWithValue("@UpdatedOn", artype.UpdatedOn);
            cmd.Parameters.AddWithValue("@CreatedBy", artype.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", artype.UpdatedBy);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<Service_type_SubDetails> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Service_type_SubDetails_GetAll"; 
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Service_type_SubDetails> area = new List<Service_type_SubDetails>();
            while (reader.Read())
            {
                Service_type_SubDetails obj = new Service_type_SubDetails(reader);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;  
        }
        
        public static Service_type_SubDetails GetById(Guid ServiceId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Service_type_SubDetails_GetById_Service";
            cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Service_type_SubDetails Service_type_SubDetails = null;
            while (reader.Read())
            {
                Service_type_SubDetails = new Service_type_SubDetails(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return Service_type_SubDetails;
        }

        public static Service_type_SubDetails FinalUpdate(Guid mainid)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Service_type_SubDetails_Final_Update";
            cmd.Parameters.AddWithValue("@MainId", mainid);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Service_type_SubDetails Service_type_SubDetails = null;
            while (reader.Read())
            {
                Service_type_SubDetails = new Service_type_SubDetails(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return Service_type_SubDetails;
        }
    }
}
