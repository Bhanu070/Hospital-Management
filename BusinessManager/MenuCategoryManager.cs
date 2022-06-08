using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObject;
using DataLayer;

namespace BusinessManager
{
    // Created By Javed Akhtar
   public class MenuCategoryManager
   {
       public static void Add(MenuCategory menucategory)
       {
           if (menucategory == null)
               throw new ArgumentException("menucategory is null.");
           MenuCategoryDB.Add(menucategory);
       }

       public static void Update(MenuCategory menucategory)
       {
           if (menucategory == null)
               throw new ArgumentException("rresult is null.");
           if (menucategory.Id == null || menucategory.Id == default(Guid))
               throw new ArgumentException("menucategory.Id value not set.");
           MenuCategoryDB.Update(menucategory);
       }

       public static void Delete(MenuCategory menucategory)
       {
           if (menucategory == null)
               throw new ArgumentException("menucategory is null.");
           if (menucategory.Id == null || menucategory.Id == default(Guid))
               throw new ArgumentException("rresult.Id value not set.");
           MenuCategoryDB.Delete(menucategory);
       }

       public static MenuCategory GetById(Guid id)
       {
           MenuCategory menucategory = null;
           menucategory = MenuCategoryDB.GetById(id);
           return menucategory;
       }

       public static List<MenuCategory> GetAll(Guid UserId)
       {
           return MenuCategoryDB.GetAll(UserId);
       }

       public static System.Data.DataSet getdataset()
       {
           return MenuCategoryDB.getdataset();
       }
       public static List<MenuCategory> Search(string Word, Guid UserId)
       {
           return MenuCategoryDB.Search(Word, UserId);
       }
   }
}


