using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
   
   public class Login: BaseObject
    {
         #region Property

       public Guid Id { get; set; }

        public int Code { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string UserPic { get; set; }
        public string UserLanguage { get; set; }
        public string Role { get; set; }
        public string DOB { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string LastLogin { get; set; }
        public string IPAddress { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }


        #endregion

        #region Other Property
        public string CourseName { get; set; }
        public string Stream { get; set; }

        public int TotalRegWaqf { get; set; }
        public int TotalPendingWaqf { get; set; }

        public int TotalFirstRti { get; set; }
        public int TotalPendingFirstRti { get; set; }

        public int TotalEncroachment { get; set; }
        public int TotalPendingEncroachment { get; set; }

        public int TotalRegManagement { get; set; }
        public int TotalPendingManagement { get; set; }

        public int TotalRecoveryProperty { get; set; }
        public int TotalPendingRecoveryProperty { get; set; }

        public int TotalComplaintWaqfManagement { get; set; }
        public int TotalPendingComplaintWaqfManagement { get; set; }

        public int TotalCertifiedCopy { get; set; }
        public int TotalPendingCertifiedCopy { get; set; }

        public int TotalInspectionRecord { get; set; }
        public int TotalPendingInspectionRecord { get; set; }


        public int TotalRTI { get; set; }
        public int TotalPendingRTI { get; set; }


        public string Kabristan { get; set; }

        #endregion

        #region UserWise Pending
        public int TotalPendingInspectionRecordUserWise { get; set; }
        public int TotalPendingCopyRecordUserWise { get; set; }

        public int TotalPendingRTIUserWise { get; set; }
        public int TotalPendingComplaintUserWise { get; set; }

        public int TotalPendingEncroachmentUserWise { get; set; }
        public int TotalPendingR_PropertyUserWise { get; set; }
        public int TotalPendingWaqf_RegUserWise { get; set; }
        public int TotalPendingManagementCommitteeUserWise { get; set; }
        public int TotalPendingTimeExtensionUserWise { get; set; }

        public string TimeExtenstion { get; set; }
        #endregion

        #region Method
        public Login()
            : base()
        {
        }

        public Login(Guid id)
            : base(id)
        {

        }

        public Login(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default(Guid);
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default(int);
            Password = DBNull.Value != reader["Password"] ? (string)reader["Password"] : default(string);
            UserName = DBNull.Value != reader["UserName"] ? (string)reader["UserName"] : default(string);
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default(string);
            MobileNo = DBNull.Value != reader["MobileNo"] ? (string)reader["MobileNo"] : default(string);
            Address = DBNull.Value != reader["Address"] ? (string)reader["Address"] : default(string);
            UserPic = DBNull.Value != reader["UserPic"] ? (string)reader["UserPic"] : default(string);
            UserLanguage = DBNull.Value != reader["UserLanguage"] ? (string)reader["UserLanguage"] : default(string);
            Role = DBNull.Value != reader["Role"] ? (string)reader["Role"] : default(string);
            DOB = DBNull.Value != reader["DOB"] ? (string)reader["DOB"] : default(string);
            Country = DBNull.Value != reader["Country"] ? (string)reader["Country"] : default(string);
            State = DBNull.Value != reader["State"] ? (string)reader["State"] : default(string);
            City = DBNull.Value != reader["City"] ? (string)reader["City"] : default(string);
            LastLogin = DBNull.Value != reader["LastLogin"] ? (string) reader["LastLogin"] : default(string);
            IPAddress = DBNull.Value != reader["IPAddress"] ? (string)reader["IPAddress"] : default(string);
            Extra1 = DBNull.Value != reader["Extra1"] ? (string)reader["Extra1"] : default(string);
            Extra2 = DBNull.Value != reader["Extra2"] ? (string)reader["Extra2"] : default(string);
            Extra3 = DBNull.Value != reader["Extra3"] ? (string)reader["Extra3"] : default(string);



        }
        #endregion
    }
}
