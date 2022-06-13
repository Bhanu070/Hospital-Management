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

    public class IPD_Main_DetailsDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        public static void Add(IPD_Main_Details artype)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("IPD_Main_Details_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("MainId", artype.MainId);
                cmd.Parameters.AddWithValue("AdmissionId", artype.AdmissionId);
                cmd.Parameters.AddWithValue("Patient_Id", artype.Patient_id);
                cmd.Parameters.AddWithValue("Doc_Id", artype.Doc_Id);
                cmd.Parameters.AddWithValue("Payment_Mode", artype.Payment_Mode);
                cmd.Parameters.AddWithValue("Admission_Date", artype.Admission_Date);
                cmd.Parameters.AddWithValue("Discharge_Date", artype.Discharge_Date);
                cmd.Parameters.AddWithValue("Bill_No", artype.Bill_No);
                cmd.Parameters.AddWithValue("Service_type", artype.Service_type);
                cmd.Parameters.AddWithValue("Total_amount", artype.Total_amount);
                cmd.Parameters.AddWithValue("Total_deduction", artype.Total_deduction);
                cmd.Parameters.AddWithValue("Advance", artype.Advance);
                cmd.Parameters.AddWithValue("Gross_total_amount", artype.Gross_total_amount);
                cmd.Parameters.AddWithValue("Additonal_discount", artype.Additonal_discount);
                cmd.Parameters.AddWithValue("TCS", artype.TCS);
                cmd.Parameters.AddWithValue("Net_total_amount", artype.Net_total_amount);
                cmd.Parameters.AddWithValue("Remarks", artype.Remarks);
                cmd.Parameters.AddWithValue("CreatedBy", artype.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedOn", artype.CreatedOn);
                cmd.Parameters.AddWithValue("UpdatedBy", artype.UpdatedBy);
                cmd.Parameters.AddWithValue("UpdatedOn", artype.UpdatedOn);
                cmd.Parameters.AddWithValue("Status", artype.Status);
                cmd.Parameters.AddWithValue("extra", artype.extra);
                cmd.Parameters.AddWithValue("extra1", artype.extra1);
                cmd.Parameters.AddWithValue("extra2", artype.extra2);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void Update(IPD_Main_Details artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("IPD_Main_Details_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MainId", artype.MainId);
            cmd.Parameters.AddWithValue("@Patient_Id", artype.Patient_id);
            cmd.Parameters.AddWithValue("@Doc_Id", artype.Doc_Id);
            cmd.Parameters.AddWithValue("@Payment_Mode", artype.Payment_Mode);
            cmd.Parameters.AddWithValue("@Admission_Date", artype.Admission_Date);
            cmd.Parameters.AddWithValue("@Additonal_discount", artype.Additonal_discount);
            cmd.Parameters.AddWithValue("@Discharge_Date", artype.Discharge_Date);
            cmd.Parameters.AddWithValue("@Advance", artype.Advance);
            cmd.Parameters.AddWithValue("@TCS", artype.TCS);
            cmd.Parameters.AddWithValue("@Remarks", artype.Remarks);
            cmd.Parameters.AddWithValue("@UpdatedBy", artype.UpdatedBy);
            cmd.Parameters.AddWithValue("@Status", artype.Status);
            cmd.Parameters.AddWithValue("@extra", artype.extra);
            cmd.Parameters.AddWithValue("@extra1", artype.extra1);
            cmd.Parameters.AddWithValue("@extra2", artype.extra2);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<IPD_Main_Details> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "IPD_Main_Details_GetAll";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<IPD_Main_Details> area = new List<IPD_Main_Details>();
            while (reader.Read())
            {
                IPD_Main_Details obj = new IPD_Main_Details(reader);
                obj.Patient_Name = DBNull.Value != reader["Patient_Name"] ? (string)reader["Patient_Name"] : default(string);
                obj.IPD_No = DBNull.Value != reader["IPD_No"] ? (string)reader["IPD_No"] : default(string);
                obj.Doc_Name = DBNull.Value != reader["Doc_Name"] ? (string)reader["Doc_Name"] : default(string);
                obj.Patient_UID = DBNull.Value != reader["Patient_UID"] ? (string)reader["Patient_UID"] : default(string);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;
        }
        public static void Delete(IPD_Main_Details artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "IPD_Main_Details_Delete";
            cmd.Parameters.AddWithValue("@AdmissionId", artype.AdmissionId);
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static IPD_Main_Details GetById(Guid AdmissionId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "IPD_Main_Details_GetById";
            cmd.Parameters.AddWithValue("@Id", AdmissionId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            IPD_Main_Details IPD_Main_Details = null;
            while (reader.Read())
            {
                IPD_Main_Details = new IPD_Main_Details(reader);
                IPD_Main_Details.IPD_No = DBNull.Value != reader["IPD_No"] ? (string)reader["IPD_No"] : default(string);
            }
            reader.Close();
            cmd.Connection.Close();
            return IPD_Main_Details;
        }
    }
}
