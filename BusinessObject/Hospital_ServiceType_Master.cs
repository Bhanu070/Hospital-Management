using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Service_type_Master : BaseObject
    {
        #region Property
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceType { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Status { get; set; }

        public int Unit { get; set; }
        public decimal PaidAmount { get; set; }

        #endregion

        #region Method
        public Service_type_Master()
            : base()
        {
        }
        public Service_type_Master(Guid id)
            : base(id)
        {
        }
        public Service_type_Master(IDataReader reader)
        {
            ServiceId = DBNull.Value != reader["ServiceId"] ? (Guid)reader["ServiceId"] : default(Guid);
            ServiceName = DBNull.Value != reader["ServiceName"] ? (string)reader["ServiceName"] : default(string);
            ServiceType = DBNull.Value != reader["ServiceType"] ? (string)reader["ServiceType"] : default(string);
            Price = DBNull.Value != reader["Price"] ? (decimal)reader["Price"] : default(decimal);
            Discount = DBNull.Value != reader["Discount"] ? (decimal)reader["Discount"] : default(decimal);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);
            UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default(string);
            CreatedOn = DBNull.Value != reader["CreatedOn"] ? (DateTime)reader["CreatedOn"] : default(DateTime);
            UpdatedOn = DBNull.Value != reader["UpdatedOn"] ? (DateTime)reader["UpdatedOn"] : default(DateTime);
        }
        #endregion
    }
}
