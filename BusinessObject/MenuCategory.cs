using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessObject
{
    // Created By Javed Akhtar
   public class MenuCategory : BaseObject
   {
       #region Property

       public Guid Id { get; set; }

       public string Name { get; set; }

       public string ExtraColumn { get; set; }

       public string Status { get; set; }

       public int Code { get; set; }

       #endregion

       #region Other Property

       #endregion

       #region Method
       public MenuCategory()
           : base()
       {
       }

       public MenuCategory(Guid id)
           : base(id)
       {

       }

       public MenuCategory(IDataReader reader)
           : base(reader)
       {
           Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default(Guid);
           Name = DBNull.Value != reader["Name"] ? (string)reader["Name"] : default(string);
           ExtraColumn = DBNull.Value != reader["ExtraColumn"] ? (string)reader["ExtraColumn"] : default(string);
           Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default(string);
           Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default(int);
       }
       #endregion
   }
}