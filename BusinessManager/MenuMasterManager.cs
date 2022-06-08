using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObject;
using DataLayer;

namespace BusinessManager
{
    // Created By Javed Akhtar
   public class MenuMasterManager
   {
       public static void Add(MenuMaster menumaster)
       {
           if (menumaster == null)
               throw new ArgumentException("menumaster is null.");
           MenuMasterDB.Add(menumaster);
       }

       public static void Update(MenuMaster menumaster)
       {
           if (menumaster == null)
               throw new ArgumentException("rresult is null.");
           if (menumaster.Id == null || menumaster.Id == default(Guid))
               throw new ArgumentException("menumaster.Id value not set.");
           MenuMasterDB.Update(menumaster);
       }

       public static void Delete(MenuMaster menumaster)
       {
           if (menumaster == null)
               throw new ArgumentException("menumaster is null.");
           if (menumaster.Id == null || menumaster.Id == default(Guid))
               throw new ArgumentException("rresult.Id value not set.");
           MenuMasterDB.Delete(menumaster);
       }

       public static MenuMaster GetById(Guid id)
       {
           MenuMaster menumaster = null;
           menumaster = MenuMasterDB.GetById(id);
           return menumaster;
       }

       public static List<MenuMaster> GetAll(Guid UserId)
       {
           return MenuMasterDB.GetAll(UserId);
       }

       public static System.Data.DataSet getdataset()
       {
           return MenuMasterDB.getdataset();
       }
       public static List<MenuMaster> Search(string Word, Guid UserId)
       {
           return MenuMasterDB.Search(Word, UserId);
       }
   }
}


