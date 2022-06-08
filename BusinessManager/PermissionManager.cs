using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataLayer;

namespace BusinessManager
{
    // Created By Javed Akhtar
   public class PermissionManager
    {
        public static void Add(Permission permission)
        {
            if (permission == null)
                throw new ArgumentException("Permission is null.");
            PermissionDB.Add(permission);
        }

        public static void Update(Permission permission)
        {
            if (permission == null)
                throw new ArgumentException("Permission is null.");
            if (permission.Id == null || permission.Id == default(Guid))
                throw new ArgumentException("Permission.Id value not set.");
            PermissionDB.Update(permission);
        }



        public static void Delete(Permission permission)
        {
            if (permission == null)
                throw new ArgumentException("Permission is null.");
            if (permission.Id == null || permission.Id == default(Guid))
                throw new ArgumentException("Permission.Id value not set.");
            PermissionDB.Delete(permission);
        }
        public static Permission GetById(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            Permission permission = null;
            permission = PermissionDB.GetById(id);
            return permission;
        }

        public static List<Permission> GetAll()
        {
            return PermissionDB.GetAll();
        }

        public static List<Permission> GetByUserId(Guid UserId)
        {
            return PermissionDB.GetByUserId(UserId);
        }
    }
}
