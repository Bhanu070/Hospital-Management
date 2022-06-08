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
   
  public   class Pathology_OPD_Main_DetailsDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        public static void Add(Pathology_OPD_Main_Details artype)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Pathology_OPD_Main_Details_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MainId", artype.MainId);               
                cmd.Parameters.AddWithValue("@Patient_Id", artype.Patient_Id);
                cmd.Parameters.AddWithValue("@Doc_Id", artype.Doc_Id);
                cmd.Parameters.AddWithValue("@Payment_Mode", artype.Payment_Mode);
                cmd.Parameters.AddWithValue("@Reciept_Date", artype.Reciept_Date);
            
                cmd.Parameters.AddWithValue("@Service_type", artype.Service_type);
                cmd.Parameters.AddWithValue("@Total_amount", artype.Total_amount);
                cmd.Parameters.AddWithValue("@Total_deduction", artype.Total_deduction);
                cmd.Parameters.AddWithValue("@Gross_total_amount", artype.Gross_total_amount);
                cmd.Parameters.AddWithValue("@Additonal_discount", artype.Additonal_discount);
                cmd.Parameters.AddWithValue("@Net_total_amount", artype.Net_total_amount);
                cmd.Parameters.AddWithValue("@Remarks", artype.Remarks);
                cmd.Parameters.AddWithValue("@CreatedBy", artype.CreatedBy);
                cmd.Parameters.AddWithValue("@UpdatedBy", artype.UpdatedBy);
               
                cmd.Parameters.AddWithValue("@extra", artype.extra);
                cmd.Parameters.AddWithValue("@extra1", artype.extra1);
                cmd.Parameters.AddWithValue("@extra2", artype.extra2);
                cmd.Parameters.AddWithValue("@Status", artype.Status);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                 throw;
            }
        }
        public static void Update(Pathology_OPD_Main_Details artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Pathology_OPD_Main_Details_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MainId", artype.MainId);
            cmd.Parameters.AddWithValue("@Patient_Id", artype.Patient_Id);
            cmd.Parameters.AddWithValue("@Doc_Id", artype.Doc_Id);
            cmd.Parameters.AddWithValue("@Payment_Mode", artype.Payment_Mode);
            cmd.Parameters.AddWithValue("@Reciept_Date", artype.Reciept_Date);
            cmd.Parameters.AddWithValue("@Total_amount", artype.Total_amount);
            cmd.Parameters.AddWithValue("@Total_deduction", artype.Total_deduction);
            cmd.Parameters.AddWithValue("@Gross_total_amount", artype.Gross_total_amount);
            cmd.Parameters.AddWithValue("@Additonal_discount", artype.Additonal_discount);
            cmd.Parameters.AddWithValue("@Net_total_amount", artype.Net_total_amount);
            cmd.Parameters.AddWithValue("@Remarks", artype.Remarks);
            cmd.Parameters.AddWithValue("@Status", artype.Status);
            cmd.Parameters.AddWithValue("@extra", artype.extra);
            cmd.Parameters.AddWithValue("@extra1", artype.extra1);
            cmd.Parameters.AddWithValue("@extra2", artype.extra2);
            cmd.Parameters.AddWithValue("@UpdatedBy", artype.UpdatedBy);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<Pathology_OPD_Main_Details> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Pathology_OPD_Main_Details_GetAll"; 
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Pathology_OPD_Main_Details> area = new List<Pathology_OPD_Main_Details>();
            while (reader.Read())
            {
                Pathology_OPD_Main_Details obj = new Pathology_OPD_Main_Details(reader);
                obj.Patient_Name = DBNull.Value != reader["Patient_Name"] ? (string)reader["Patient_Name"] : default(string);
                obj.Patient_UID = DBNull.Value != reader["Patient_UID"] ? (string)reader["Patient_UID"] : default(string);
                obj.Doc_Name = DBNull.Value != reader["Doc_Name"] ? (string)reader["Doc_Name"] : default(string);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;  
        }
        public static void Delete(Pathology_OPD_Main_Details  artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Pathology_OPD_Main_Details_Delete";
            cmd.Parameters.AddWithValue("@Patient_Id", artype.Patient_Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static Pathology_OPD_Main_Details GetById(Guid Id)
        {

            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Pathology_OPD_Main_Details_GetById";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Pathology_OPD_Main_Details Pathology_OPD_Main_Details = null;
            while (reader.Read())
            {
                Pathology_OPD_Main_Details = new Pathology_OPD_Main_Details(reader);
                Pathology_OPD_Main_Details.PaidAmount = DBNull.Value != reader["PaidAmount"] ? (decimal)reader["PaidAmount"] : default(decimal);
            }
            reader.Close();
            cmd.Connection.Close();
            return Pathology_OPD_Main_Details;


            //SqlConnection con = new SqlConnection(connection);
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "Pathology_OPD_Main_Details_GetById";
            //cmd.Parameters.AddWithValue("@Id", Id);
            //cmd.Connection = con;
            //cmd.Connection.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //Pathology_OPD_Main_Details Pathology_OPD_Main_Details = null;
            //while (reader.Read())
            //{
            //    Pathology_OPD_Main_Details obj = new Pathology_OPD_Main_Details(reader);
            //    obj.PaidAmount = DBNull.Value != reader["PaidAmount"] ? (decimal)reader["PaidAmount"] : default(decimal);
               
            //}
            //reader.Close();
            //cmd.Connection.Close();
            //return Pathology_OPD_Main_Details;
        }


        public static List<Pathology_OPD_Main_Details> GetAll_Pending(string status)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Pathology_OPD_Main_Details_GetAll_Pending";
            cmd.Parameters.AddWithValue("@status",status);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Pathology_OPD_Main_Details> area = new List<Pathology_OPD_Main_Details>();
            while (reader.Read())
            {
                Pathology_OPD_Main_Details obj = new Pathology_OPD_Main_Details(reader);
                obj.Patient_Name = DBNull.Value != reader["Patient_Name"] ? (string)reader["Patient_Name"] : default(string);
                obj.Patient_UID = DBNull.Value != reader["Patient_UID"] ? (string)reader["Patient_UID"] : default(string);
                obj.Doc_Name = DBNull.Value != reader["Doc_Name"] ? (string)reader["Doc_Name"] : default(string);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;
        }
    }
}
