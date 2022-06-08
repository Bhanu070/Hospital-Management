using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    // Created By Javed Akhtar
   public  class Permission:BaseObject
    {
       #region Property

       public Guid Id { get; set; }

        public int Code { get; set; }
        public Guid UserId { get; set; }
        public string MenuName { get; set; }
        public string AddRecord { get; set; }
        public string UpdateRecord { get; set; }
        public string DeleteRecord { get; set; }
        public string ExtraColumn { get; set; }
        public string Status { get; set; }
       


        #endregion


        #region Method
        public Permission()
            : base()
        {
        }

        public Permission(Guid id)
            : base(id)
        {

        }

        public Permission(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default(Guid);
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default(int);
            MenuName = DBNull.Value != reader["MenuName"] ? (string)reader["MenuName"] : default(string);
            UserId = DBNull.Value != reader["UserId"] ? (Guid)reader["UserId"] : default(Guid);
            AddRecord = DBNull.Value != reader["AddRecord"] ? (string)reader["AddRecord"] : default(string);
            UpdateRecord = DBNull.Value != reader["UpdateRecord"] ? (string)reader["UpdateRecord"] : default(string);
            DeleteRecord = DBNull.Value != reader["DeleteRecord"] ? (string)reader["DeleteRecord"] : default(string);
            ExtraColumn = DBNull.Value != reader["ExtraColumn"] ? (string)reader["ExtraColumn"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);

        }
        #endregion
    }
}
