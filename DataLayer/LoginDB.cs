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
    public class LoginDB
    {
        public static string connection = ConfigurationSettings.AppSettings["ConnectionInfo"];

        public static void Add(Login Login)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Usp_Login_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Login.Id);
                cmd.Parameters.AddWithValue("@Address", Login.Address);
                cmd.Parameters.AddWithValue("@City", Login.City);
                cmd.Parameters.AddWithValue("@Country", Login.Country);
                cmd.Parameters.AddWithValue("@DOB", Login.DOB);
                cmd.Parameters.AddWithValue("@Email", Login.Email);
                cmd.Parameters.AddWithValue("@Extra1", Login.Extra1);
                cmd.Parameters.AddWithValue("@Extra2", Login.Extra2);
                cmd.Parameters.AddWithValue("@Extra3", Login.Extra3);
                cmd.Parameters.AddWithValue("@IPAddress", Login.IPAddress);
                cmd.Parameters.AddWithValue("@LastLogin", Login.LastLogin);
                cmd.Parameters.AddWithValue("@MobileNo", Login.MobileNo);
                cmd.Parameters.AddWithValue("@Password", Login.Password);
                cmd.Parameters.AddWithValue("@Role", Login.Role);
                cmd.Parameters.AddWithValue("@State", Login.State);
                cmd.Parameters.AddWithValue("@UserLanguage", Login.UserLanguage);
                cmd.Parameters.AddWithValue("@UserName", Login.UserName);
                cmd.Parameters.AddWithValue("@UserPic", Login.UserPic);
                cmd.Parameters.AddWithValue("@CreatedBy", Login.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedOn", Login.CreatedOn);
                cmd.Parameters.AddWithValue("@UpdatedBy", Login.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedOn", Login.UpdatedOn);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static void Update(Login Login)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("Usp_Login_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Login.Id);
            cmd.Parameters.AddWithValue("@Address", Login.Address);
            cmd.Parameters.AddWithValue("@City", Login.City);
            cmd.Parameters.AddWithValue("@Country", Login.Country);
            cmd.Parameters.AddWithValue("@DOB", Login.DOB);
            cmd.Parameters.AddWithValue("@Email", Login.Email);
            cmd.Parameters.AddWithValue("@Extra1", Login.Extra1);
            cmd.Parameters.AddWithValue("@Extra2", Login.Extra2);
            cmd.Parameters.AddWithValue("@Extra3", Login.Extra3);
            cmd.Parameters.AddWithValue("@IPAddress", Login.IPAddress);
            cmd.Parameters.AddWithValue("@LastLogin", Login.LastLogin);
            cmd.Parameters.AddWithValue("@MobileNo", Login.MobileNo);
            cmd.Parameters.AddWithValue("@Password", Login.Password);
            cmd.Parameters.AddWithValue("@Role", Login.Role);
            cmd.Parameters.AddWithValue("@State", Login.State);
            cmd.Parameters.AddWithValue("@UserLanguage", Login.UserLanguage);
            cmd.Parameters.AddWithValue("@UserName", Login.UserName);
            cmd.Parameters.AddWithValue("@UserPic", Login.UserPic);
            cmd.Parameters.AddWithValue("@UpdatedBy", Login.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", Login.UpdatedOn);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<Login> GetAll()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Login_GetAll";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> Product = new List<Login>();
            while (reader.Read())
            {
                Login Obj = new Login(reader);
                //Obj.CourseName = DBNull.Value != reader["CourseName"] ? (string)reader["CourseName"] : default(string);
                //Obj.Stream = DBNull.Value != reader["Stream"] ? (string)reader["Stream"] : default(string);
                Product.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return Product;
        }
        public static List<Login> GetAllDelete()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Login_GetAllDelete";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Login> Product = new List<Login>();
            while (reader.Read())
            {
                Login Obj = new Login(reader);
                Product.Add(Obj);
            }
            reader.Close();
            cmd.Connection.Close();
            return Product;
        }

        public static void Delete(Login Login)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Login_Delete";
            cmd.Parameters.AddWithValue("@Id", Login.Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static Login GetById(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Login_GetById";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Login Login = null;
            while (reader.Read())
            {
                Login = new Login(reader);
             




            }
    reader.Close();
            cmd.Connection.Close();

            return Login;

        }
        public static void UpdatePassword(Login Login)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("usp_Login_UpdatePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Login.Id);
            cmd.Parameters.AddWithValue("@Password", Login.Password);
            cmd.Parameters.AddWithValue("@CreatedBy", Login.CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedOn", Login.CreatedOn);
            cmd.Parameters.AddWithValue("@UpdatedBy", Login.UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedOn", Login.UpdatedOn);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static Login RecoverPassword(string Name)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Login_GetByName";
            cmd.Parameters.AddWithValue("@UserName", Name);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Login Login = null;
            while (reader.Read())
            {
                Login = new Login(reader);
            }
            reader.Close();
            cmd.Connection.Close();

            return Login;

        }
        public static Login Login(String Name, string Password)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Login_Login";
            cmd.Parameters.AddWithValue("@UserName", Name);
           cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Login Login = null;
            while (reader.Read())
            {
                Login = new Login(reader);
                //Login.TotalRegWaqf = DBNull.Value != reader["TotalRegWaqf"] ? (int)reader["TotalRegWaqf"] : default(int);
                //Login.TotalPendingWaqf = DBNull.Value != reader["TotalPendingWaqf"] ? (int)reader["TotalPendingWaqf"] : default(int);
                //Login.Kabristan = DBNull.Value != reader["Kabristan"] ? (string)reader["Kabristan"] : default(string);
            }
            reader.Close();
            cmd.Connection.Close();

            return Login;

        }
        public static Login GetById_UserWise(Guid Id)
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Usp_Login_GetById_UserWise";
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Login Login = null;
            while (reader.Read())
            {
                Login = new Login(reader);
                Login.TotalPendingInspectionRecordUserWise = DBNull.Value != reader["TotalPendingInspectionRecordUserWise"] ? (int)reader["TotalPendingInspectionRecordUserWise"] : default(int);
                Login.TotalPendingCopyRecordUserWise = DBNull.Value != reader["TotalPendingCopyRecordUserWise"] ? (int)reader["TotalPendingCopyRecordUserWise"] : default(int);

                Login.TotalPendingRTIUserWise = DBNull.Value != reader["TotalPendingRTIUserWise"] ? (int)reader["TotalPendingRTIUserWise"] : default(int);
                Login.TotalPendingComplaintUserWise = DBNull.Value != reader["TotalPendingComplaintUserWise"] ? (int)reader["TotalPendingComplaintUserWise"] : default(int);

                Login.TotalPendingEncroachmentUserWise = DBNull.Value != reader["TotalPendingEncroachmentUserWise"] ? (int)reader["TotalPendingEncroachmentUserWise"] : default(int);
                Login.TotalPendingR_PropertyUserWise = DBNull.Value != reader["TotalPendingR_PropertyUserWise"] ? (int)reader["TotalPendingR_PropertyUserWise"] : default(int);

                Login.TotalPendingWaqf_RegUserWise = DBNull.Value != reader["TotalPendingWaqf_RegUserWise"] ? (int)reader["TotalPendingWaqf_RegUserWise"] : default(int);
                Login.TotalPendingManagementCommitteeUserWise = DBNull.Value != reader["TotalPendingManagementCommitteeUserWise"] ? (int)reader["TotalPendingManagementCommitteeUserWise"] : default(int);
                Login.TotalPendingTimeExtensionUserWise = DBNull.Value != reader["TotalPendingTimeExtensionUserWise"] ? (int)reader["TotalPendingTimeExtensionUserWise"] : default(int);

            }
            reader.Close();
            cmd.Connection.Close();

            return Login;

        }

    }

}
