using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class IPD_Admission_Slip : BaseObject
    {
        #region Property
        public int Code { get; set; }
        public Guid AdmissionId { get; set; }
        public Guid Patient_id { get; set; }
        public string Registration_Type { get; set; }
        public Guid OPD_RegistrationId { get; set; }
        public string IPD_No { get; set; }
        public string Consultant_Name { get; set; }
        public string ReferredBy { get; set; }
        public string WardName { get; set; }
        public string RoomName { get; set; }
        public int BedNo { get; set; }
        public string AC_Normal { get; set; }
        public string Status { get; set; }
        public string extra { get; set; }
        public string extra1 { get; set; }
        public string extra2 { get; set; }
        public DateTime Ipd_Reg_Date { get; set; }

        public string Patient_Name { get; set; }
        public string OP_No { get; set; }

        #endregion

        #region Method
        public IPD_Admission_Slip()
            : base()
        {
        }
        public IPD_Admission_Slip(Guid id)
            : base(id)
        {
        }
        public IPD_Admission_Slip(IDataReader reader)
        {
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default(int);
            AdmissionId = DBNull.Value != reader["AdmissionId"] ? (Guid)reader["AdmissionId"] : default(Guid);
            Registration_Type = DBNull.Value != reader["Registration_Type"] ? (string)reader["Registration_Type"] : default(string);
            Patient_id = DBNull.Value != reader["Patient_id"] ? (Guid)reader["Patient_id"] : default(Guid);
            OPD_RegistrationId = DBNull.Value != reader["OPD_RegistrationId"] ? (Guid)reader["OPD_RegistrationId"] : default(Guid);
            IPD_No = DBNull.Value != reader["IPD_No"] ? (string)reader["IPD_No"] : default(string);
            Consultant_Name = DBNull.Value != reader["Consultant_Name"] ? (string)reader["Consultant_Name"] : default(string);
            ReferredBy = DBNull.Value != reader["ReferredBy"] ? (string)reader["ReferredBy"] : default(string);
            WardName = DBNull.Value != reader["WardName"] ? (string)reader["WardName"] : default(string);
            RoomName = DBNull.Value != reader["RoomName"] ? (string)reader["RoomName"] : default(string);
            BedNo = DBNull.Value != reader["BedNo"] ? (int)reader["BedNo"] : default(int);
            AC_Normal = DBNull.Value != reader["AC_Normal"] ? (string)reader["AC_Normal"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
            extra = DBNull.Value != reader["extra"] ? (string)reader["extra"] : default(string);
            extra1 = DBNull.Value != reader["extra1"] ? (string)reader["extra1"] : default(string);
            extra2 = DBNull.Value != reader["extra2"] ? (string)reader["extra2"] : default(string);
            Ipd_Reg_Date = DBNull.Value != reader["Ipd_Reg_Date"] ? (DateTime)reader["Ipd_Reg_Date"] : default(DateTime);
            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);
            UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default(string);
            CreatedOn = DBNull.Value != reader["CreatedOn"] ? (DateTime)reader["CreatedOn"] : default(DateTime);
            UpdatedOn = DBNull.Value != reader["UpdatedOn"] ? (DateTime)reader["UpdatedOn"] : default(DateTime);
        }
        #endregion
    }
}
