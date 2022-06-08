using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataLayer;


namespace BusinessManager
{
   public  class Patient_MasterManager
    {
        public static void Add(Patient_Master bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Patient_Master is null.");
            Patient_MasterDB.Add(bgm);
        }
        public static void Update(Patient_Master bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Patient_Master is null.");
            // if (bgm.Id == null || bgm.Id == default(Guid))
            if (bgm.Patient_Id == null || bgm.Patient_Id == default(Guid))
                throw new ArgumentException("Patient_Master.Id value not set.");
            Patient_MasterDB.Update(bgm);
        }
        public static void Delete(Patient_Master bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Patient_Master is null.");
            if (bgm.Patient_Id == null || bgm.Patient_Id == default(Guid))
                throw new ArgumentException("Patient_Master.Id value not set.");
            Patient_MasterDB.Delete(bgm);
        }
        public static Patient_Master GetById(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            Patient_Master bgm = null;
            bgm = Patient_MasterDB.GetById(id);
            return bgm;
        }
        public static List<Patient_Master> GetAll()
        {
            return Patient_MasterDB.GetAll();
        }
    }
}
