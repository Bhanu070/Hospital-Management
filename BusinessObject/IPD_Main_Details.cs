using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class IPD_Main_Details : BaseObject
    {
        #region Property
        public int Code { get; set; }
        public Guid MainId { get; set; }
        public Guid AdmissionId { get; set; }
        public Guid Patient_id { get; set; }
        public Guid Doc_Id { get; set; }
        public string Payment_Mode { get; set; }
        public DateTime Admission_Date { get; set; }
        public DateTime Discharge_Date { get; set; }
        public string Bill_No { get; set; }
        public string Service_type { get; set; }
        public decimal Total_amount { get; set; }
        public decimal Total_deduction { get; set; }
        public decimal Advance { get; set; }
        public decimal Gross_total_amount { get; set; }
        public decimal Additonal_discount { get; set; }
        public decimal TCS { get; set; }
        public decimal Net_total_amount { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string extra { get; set; }
        public string extra1 { get; set; }
        public string extra2 { get; set; }


        public string Patient_Name { get; set; }
        public string IPD_No { get; set; }
        public string Doc_Name { get; set; }

        public string Patient_UID { get; set; }

        #endregion

        #region Method
        public IPD_Main_Details()
            : base()
        {
        }
        public IPD_Main_Details(Guid id)
            : base(id)
        {
        }
        public IPD_Main_Details(IDataReader reader)
        {
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default(int);
            MainId = DBNull.Value != reader["MainId"] ? (Guid)reader["MainId"] : default(Guid);
            AdmissionId = DBNull.Value != reader["AdmissionId"] ? (Guid)reader["AdmissionId"] : default(Guid);
            Discharge_Date = DBNull.Value != reader["Discharge_Date"] ? (DateTime)reader["Discharge_Date"] : default(DateTime);
            Patient_id = DBNull.Value != reader["Patient_id"] ? (Guid)reader["Patient_id"] : default(Guid);
            Doc_Id = DBNull.Value != reader["Doc_Id"] ? (Guid)reader["Doc_Id"] : default(Guid);
            Bill_No = DBNull.Value != reader["Bill_No"] ? (string)reader["Bill_No"] : default(string);
            Service_type = DBNull.Value != reader["Service_type"] ? (string)reader["Service_type"] : default(string);
            Payment_Mode = DBNull.Value != reader["Payment_Mode"] ? (string)reader["Payment_Mode"] : default(string);
            Total_amount = DBNull.Value != reader["Total_amount"] ? (decimal)reader["Total_amount"] : default(decimal);
            Total_deduction = DBNull.Value != reader["Total_deduction"] ? (decimal)reader["Total_deduction"] : default(decimal);
            Advance = DBNull.Value != reader["Advance"] ? (decimal)reader["Advance"] : default(decimal);
            Gross_total_amount = DBNull.Value != reader["Gross_total_amount"] ? (decimal)reader["Gross_total_amount"] : default(decimal);
            Additonal_discount = DBNull.Value != reader["Additonal_discount"] ? (decimal)reader["Additonal_discount"] : default(decimal);
            TCS = DBNull.Value != reader["TCS"] ? (decimal)reader["TCS"] : default(decimal);
            Net_total_amount = DBNull.Value != reader["Net_total_amount"] ? (decimal)reader["Net_total_amount"] : default(decimal);
            Remarks = DBNull.Value != reader["Remarks"] ? (string)reader["Remarks"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
            extra = DBNull.Value != reader["extra"] ? (string)reader["extra"] : default(string);
            extra1 = DBNull.Value != reader["extra1"] ? (string)reader["extra1"] : default(string);
            extra2 = DBNull.Value != reader["extra2"] ? (string)reader["extra2"] : default(string);
            Admission_Date = DBNull.Value != reader["Admission_Date"] ? (DateTime)reader["Admission_Date"] : default(DateTime);
            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);
            UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default(string);
            CreatedOn = DBNull.Value != reader["CreatedOn"] ? (DateTime)reader["CreatedOn"] : default(DateTime);
            UpdatedOn = DBNull.Value != reader["UpdatedOn"] ? (DateTime)reader["UpdatedOn"] : default(DateTime);
        }
        #endregion
    }
}
