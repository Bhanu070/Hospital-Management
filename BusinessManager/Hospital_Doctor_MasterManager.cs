using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataLayer;


namespace BusinessManager
{
   public  class Doctor_MasterManager
    {
        public static void Add(Doctor_Master bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Doctor_Master is null.");
            Doctor_MasterDB.Add(bgm);
        }
        public static void Update(Doctor_Master bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Doctor_Master is null.");
            // if (bgm.Id == null || bgm.Id == default(Guid))
            if (bgm.Doc_Id == null || bgm.Doc_Id == default(Guid))
                throw new ArgumentException("Doctor_Master.Id value not set.");
            Doctor_MasterDB.Update(bgm);
        }
        public static void Delete(Doctor_Master bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Doctor_Master is null.");
            if (bgm.Doc_Id == null || bgm.Doc_Id == default(Guid))
                throw new ArgumentException("Doctor_Master.Id value not set.");
            Doctor_MasterDB.Delete(bgm);
        }
        public static Doctor_Master GetById(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            Doctor_Master bgm = null;
            bgm = Doctor_MasterDB.GetById(id);
            return bgm;
        }
        public static List<Doctor_Master> GetAll()
        {
            return Doctor_MasterDB.GetAll();
        }
    }
}
