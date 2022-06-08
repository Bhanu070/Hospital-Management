using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessObject
{
    // Created By Javed Akhtar
   public class MenuMaster : BaseObject
   {
       #region Property

       public Guid Id { get; set; }

       public string Name { get; set; }

       public string AddId { get; set; }

       public string EditId { get; set; }

       public string DeleteId { get; set; }

       public string ExtraColumn { get; set; }

       public string Status { get; set; }

       public int Code { get; set; }

       #endregion

       #region Other Property

       public string AddRecord { get; set; }

       public string EditRecord { get; set; }

       public string DeleteRecord { get; set; }

       public string ViewRecord { get; set; }

       #endregion

       #region Method
       public MenuMaster()
           : base()
       {
       }

       public MenuMaster(Guid id)
           : base(id)
       {

       }

       public MenuMaster(IDataReader reader)
           : base(reader)
       {
           Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default(Guid);
           Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default(string);
           AddId = DBNull.Value != reader["AddId"] ? (string)reader["AddId"] : default(string);
           EditId = DBNull.Value != reader["EditId"] ? (string)reader["EditId"] : default(string);
           DeleteId = DBNull.Value != reader["DeleteId"] ? (string)reader["DeleteId"] : default(string);
           ExtraColumn = DBNull.Value != reader["ExtraColumn"] ? (string)reader["ExtraColumn"] : default(string);
           Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
           Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default(int);
       }
       #endregion
   }
}