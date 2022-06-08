using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Patient_Master : BaseObject
    {
        #region Property
        public Guid Patient_Id { get; set; }
        public string Patient_Name { get; set; }
        public string Patient_UID { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        #endregion

        #region Method
        public Patient_Master()
            : base()
        {
        }
        public Patient_Master(Guid id)
            : base(id)
        {
        }
        public Patient_Master(IDataReader reader)
        {
            Patient_Id = DBNull.Value != reader["Patient_Id"] ? (Guid)reader["Patient_Id"] : default(Guid);
            Patient_Name = DBNull.Value != reader["Patient_Name"] ? (string)reader["Patient_Name"] : default(string);
            Patient_UID = DBNull.Value != reader["Patient_UID"] ? (string)reader["Patient_UID"] : default(string);
            Age = DBNull.Value != reader["Age"] ? (int)reader["Age"] : default(int);
            Sex = DBNull.Value != reader["Sex"] ? (string)reader["Sex"] : default(string);
            MobileNo = DBNull.Value != reader["MobileNo"] ? (string)reader["MobileNo"] : default(string);
            Address = DBNull.Value != reader["Address"] ? (string)reader["Address"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);
            UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default(string);
            CreatedOn = DBNull.Value != reader["CreatedOn"] ? (DateTime)reader["CreatedOn"] : default(DateTime);
            UpdatedOn = DBNull.Value != reader["UpdatedOn"] ? (DateTime)reader["UpdatedOn"] : default(DateTime);
        }
        #endregion
    }
}
