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
   
  public   class Service_type_MasterDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        public static void Add(Service_type_Master artype)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Service_type_Master_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceId", artype.ServiceId);               
                cmd.Parameters.AddWithValue("@ServiceName", artype.ServiceName);
                cmd.Parameters.AddWithValue("@ServiceType", artype.ServiceType);
                cmd.Parameters.AddWithValue("@Price", artype.Price);
                cmd.Parameters.AddWithValue("@Discount", artype.Discount);
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
        public static void Update(Service_type_Master artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Service_type_Master_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ServiceId", artype.ServiceId);
            cmd.Parameters.AddWithValue("@ServiceName", artype.ServiceName);
            cmd.Parameters.AddWithValue("@ServiceType", artype.ServiceType);
            cmd.Parameters.AddWithValue("@Price", artype.Price);
            cmd.Parameters.AddWithValue("@Discount", artype.Discount);
            cmd.Parameters.AddWithValue("@Status", artype.Status);

            cmd.Parameters.AddWithValue("@CreatedOn", artype.CreatedOn);
            cmd.Parameters.AddWithValue("@UpdatedOn", artype.UpdatedOn);
            cmd.Parameters.AddWithValue("@CreatedBy", artype.CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", artype.UpdatedBy);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<Service_type_Master> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Service_type_Master_GetAll"; 
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Service_type_Master> area = new List<Service_type_Master>();
            while (reader.Read())
            {
                Service_type_Master obj = new Service_type_Master(reader);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;  
        }
        public static List<Service_type_Master> GetAll_All()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Service_type_Master_GetAll_All";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Service_type_Master> area = new List<Service_type_Master>();
            while (reader.Read())
            {
                Service_type_Master obj = new Service_type_Master(reader);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;
        }


        public static List<Service_type_Master> GetAll_Service(string type)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Service_type_Master_GetAll_Service";
            cmd.Parameters.AddWithValue("@ServiceType", type);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Service_type_Master> area = new List<Service_type_Master>();
            while (reader.Read())
            {
                Service_type_Master obj = new Service_type_Master(reader);
                obj.Unit = DBNull.Value != reader["Unit"] ? (int)reader["Unit"] : default(int);
                obj.PaidAmount = DBNull.Value != reader["PaidAmount"] ? (decimal)reader["PaidAmount"] : default(decimal);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;
        }

        public static List<Service_type_Master> GetAll_Service_GetById(string type,Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Service_type_Master_GetAll_Service_GetById";
            cmd.Parameters.AddWithValue("@ServiceType", type);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Service_type_Master> area = new List<Service_type_Master>();
            while (reader.Read())
            {
                Service_type_Master obj = new Service_type_Master(reader);
                obj.Unit = DBNull.Value != reader["Unit"] ? (int)reader["Unit"] : default(int);
                obj.PaidAmount = DBNull.Value != reader["PaidAmount"] ? (decimal)reader["PaidAmount"] : default(decimal);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;
        }
       
        public static void Delete(Service_type_Master  artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Service_type_Master_Delete";
            cmd.Parameters.AddWithValue("@ServiceId", artype.ServiceId);
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static Service_type_Master GetById(Guid ServiceId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Service_type_Master_GetById";
            cmd.Parameters.AddWithValue("@ServiceId", ServiceId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Service_type_Master Service_type_Master = null;
            while (reader.Read())
            {
                Service_type_Master = new Service_type_Master(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return Service_type_Master;
        }


        public static List<Service_type_Master> GetByServiceType(string ServiceType)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Service_type_Master_GetByService";
            cmd.Parameters.AddWithValue("@ServiceType", ServiceType);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Service_type_Master> area = new List<Service_type_Master>();
            while (reader.Read())
            {
                Service_type_Master obj = new Service_type_Master(reader);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;
        }
    }
}
