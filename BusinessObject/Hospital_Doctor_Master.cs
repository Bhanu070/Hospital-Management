using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Doctor_Master : BaseObject
    {
        #region Property
        public Guid Doc_Id { get; set; }
        public string Doc_Name { get; set; }
        public Guid QualificationID { get; set; }
        public string Qualification { get; set; }
        public string Status { get; set; }

        //public string CREATED_BY { get; set; }
        //public string UPDATED_BY { get; set; }
        //public string CREATED_ON { get; set; }
        //public string UPDATED_ON { get; set; }
        #endregion

        #region Method
        public Doctor_Master()
            : base()
        {
        }
        public Doctor_Master(Guid id)
            : base(id)
        {
        }
        public Doctor_Master(IDataReader reader)
        {
            Doc_Id = DBNull.Value != reader["Doc_Id"] ? (Guid)reader["Doc_Id"] : default(Guid);
            Doc_Name = DBNull.Value != reader["Doc_Name"] ? (string)reader["Doc_Name"] : default(string);
            QualificationID = DBNull.Value != reader["QualificationID"] ? (Guid)reader["QualificationID"] : default(Guid);
            Qualification = DBNull.Value != reader["Qualification"] ? (string)reader["Qualification"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);
            UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default(string);
            CreatedOn = DBNull.Value != reader["CreatedOn"] ? (DateTime)reader["CreatedOn"] : default(DateTime);
            UpdatedOn = DBNull.Value != reader["UpdatedOn"] ? (DateTime)reader["UpdatedOn"] : default(DateTime);
        }
        #endregion
    }
}
