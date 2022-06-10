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

    public class IPD_Admission_SlipDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];
        public static void Add(IPD_Admission_Slip artype)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("IPD_Admission_Slip_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("AdmissionId", artype.AdmissionId);
                cmd.Parameters.AddWithValue("Patient_id", artype.Patient_id);
                cmd.Parameters.AddWithValue("Registration_Type", artype.Registration_Type);
                cmd.Parameters.AddWithValue("OPD_RegistrationId", artype.OPD_RegistrationId);
               // cmd.Parameters.AddWithValue("IPD_No", artype.IPD_No);
                cmd.Parameters.AddWithValue("Consultant_Name", artype.Consultant_Name);
                cmd.Parameters.AddWithValue("ReferredBy", artype.ReferredBy);
                cmd.Parameters.AddWithValue("WardName", artype.WardName);
                cmd.Parameters.AddWithValue("RoomName", artype.RoomName);
                cmd.Parameters.AddWithValue("BedNo", artype.BedNo);
                cmd.Parameters.AddWithValue("AC_Normal", artype.AC_Normal);
                cmd.Parameters.AddWithValue("CreatedBy", artype.CreatedBy);
                cmd.Parameters.AddWithValue("CreatedOn", artype.CreatedOn);
                cmd.Parameters.AddWithValue("UpdatedBy", artype.UpdatedBy);
                cmd.Parameters.AddWithValue("UpdatedOn", artype.UpdatedOn);
                cmd.Parameters.AddWithValue("Status", artype.Status);
                cmd.Parameters.AddWithValue("extra", artype.extra);
                cmd.Parameters.AddWithValue("extra1", artype.extra1);
                cmd.Parameters.AddWithValue("extra2", artype.extra2);
                cmd.Parameters.AddWithValue("Ipd_Reg_Date", artype.Ipd_Reg_Date);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void Update(IPD_Admission_Slip artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("IPD_Admission_Slip_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("AdmissionId", artype.AdmissionId);
            cmd.Parameters.AddWithValue("Patient_id", artype.Patient_id);
            cmd.Parameters.AddWithValue("Registration_Type", artype.Registration_Type);
            cmd.Parameters.AddWithValue("OPD_RegistrationId", artype.OPD_RegistrationId);
            //cmd.Parameters.AddWithValue("IPD_No", artype.IPD_No);
            cmd.Parameters.AddWithValue("Consultant_Name", artype.Consultant_Name);
            cmd.Parameters.AddWithValue("ReferredBy", artype.ReferredBy);
            cmd.Parameters.AddWithValue("WardName", artype.WardName);
            cmd.Parameters.AddWithValue("RoomName", artype.RoomName);
            cmd.Parameters.AddWithValue("BedNo", artype.BedNo);
            cmd.Parameters.AddWithValue("AC_Normal", artype.AC_Normal);
            cmd.Parameters.AddWithValue("CreatedBy", artype.CreatedBy);
            cmd.Parameters.AddWithValue("CreatedOn", artype.CreatedOn);
            cmd.Parameters.AddWithValue("UpdatedBy", artype.UpdatedBy);
            cmd.Parameters.AddWithValue("UpdatedOn", artype.UpdatedOn);
            cmd.Parameters.AddWithValue("Status", artype.Status);
            cmd.Parameters.AddWithValue("extra", artype.extra);
            cmd.Parameters.AddWithValue("extra1", artype.extra1);
            cmd.Parameters.AddWithValue("extra2", artype.extra2);
            cmd.Parameters.AddWithValue("Ipd_Reg_Date", artype.Ipd_Reg_Date);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<IPD_Admission_Slip> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "IPD_Admission_Slip_GetAll";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<IPD_Admission_Slip> area = new List<IPD_Admission_Slip>();
            while (reader.Read())
            {
                IPD_Admission_Slip obj = new IPD_Admission_Slip(reader);
                obj.Patient_Name = DBNull.Value != reader["Patient_Name"] ? (string)reader["Patient_Name"] : default(string);
                obj.OP_No = DBNull.Value != reader["OP_No"] ? (string)reader["OP_No"] : default(string);
                area.Add(obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return area;
        }
        public static void Delete(IPD_Admission_Slip artype)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "IPD_Admission_Slip_Delete";
            cmd.Parameters.AddWithValue("@AdmissionId", artype.AdmissionId);
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static IPD_Admission_Slip GetById(Guid AdmissionId)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "IPD_Admission_Slip_GetById";
            cmd.Parameters.AddWithValue("@Id", AdmissionId);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            IPD_Admission_Slip IPD_Admission_Slip = null;
            while (reader.Read())
            {
                IPD_Admission_Slip = new IPD_Admission_Slip(reader);
            }
            reader.Close();
            cmd.Connection.Close();
            return IPD_Admission_Slip;
        }
    }
}
