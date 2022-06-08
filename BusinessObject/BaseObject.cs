using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace BusinessObject 
{
    // Created By Javed Akhtar
    public abstract class BaseObject
    {

        #region Properties
        //public Guid Id { get; private set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        #endregion

        public BaseObject()
        {
            //Id = Guid.NewGuid();
        }
        public BaseObject(Guid id)
        {
            //Id = id;
        }

        public BaseObject(Guid id, string createdBy, DateTime createdOn, string updatedBy, DateTime updatedOn)
        {
            //Id = id;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            UpdatedBy = updatedBy;
            UpdatedOn = updatedOn;
        }


        public BaseObject(IDataReader reader)
        {
            //Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default(Guid);
            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);
            CreatedOn = DBNull.Value != reader["CreatedOn"] ? (DateTime)reader["CreatedOn"] : default(DateTime);
            UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default(string);
            UpdatedOn = DBNull.Value != reader["UpdatedOn"] ? (DateTime)reader["UpdatedOn"] : default(DateTime);

        }

        public BaseObject(DataRow row)
        {
            //Id = DBNull.Value != row["Id"] ? (Guid)row["Id"] : default(Guid);
            CreatedBy = DBNull.Value != row["CreatedBy"] ? (string)row["CreatedBy"] : default(string);
            CreatedOn = DBNull.Value != row["CreatedOn"] ? (DateTime)row["CreatedOn"] : default(DateTime);
            UpdatedBy = DBNull.Value != row["UpdatedBy"] ? (string)row["UpdatedBy"] : default(string);
            UpdatedOn = DBNull.Value != row["UpdatedOn"] ? (DateTime)row["UpdatedOn"] : default(DateTime);

        }

        public BaseObject(BaseObject obj)
        {
            //Id = obj.Id;
            CreatedBy = obj.CreatedBy;
            CreatedOn = obj.CreatedOn;
            UpdatedBy = obj.UpdatedBy;
            UpdatedOn = obj.UpdatedOn;
        }
    }
}
