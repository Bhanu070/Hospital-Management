using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataLayer;


namespace BusinessManager
{
   public  class Pathology_OPD_Main_DetailsManager
    {
        public static void Add(Pathology_OPD_Main_Details bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Pathology_OPD_Main_Details is null.");
            Pathology_OPD_Main_DetailsDB.Add(bgm);
        }
        public static void Update(Pathology_OPD_Main_Details bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Pathology_OPD_Main_Details is null.");
            // if (bgm.Id == null || bgm.Id == default(Guid))
            if (bgm.Patient_Id == null || bgm.Patient_Id == default(Guid))
                throw new ArgumentException("Pathology_OPD_Main_Details.Id value not set.");
            Pathology_OPD_Main_DetailsDB.Update(bgm);
        }
        public static void Delete(Pathology_OPD_Main_Details bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Pathology_OPD_Main_Details is null.");
            if (bgm.Patient_Id == null || bgm.Patient_Id == default(Guid))
                throw new ArgumentException("Pathology_OPD_Main_Details.Id value not set.");
            Pathology_OPD_Main_DetailsDB.Delete(bgm);
        }
        public static Pathology_OPD_Main_Details GetById(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            Pathology_OPD_Main_Details bgm = null;
            bgm = Pathology_OPD_Main_DetailsDB.GetById(id);
            return bgm;
        }
        public static List<Pathology_OPD_Main_Details> GetAll()
        {
            return Pathology_OPD_Main_DetailsDB.GetAll();
        }
        public static List<Pathology_OPD_Main_Details> GetAll_Pending(string pending)
        {
            return Pathology_OPD_Main_DetailsDB.GetAll_Pending(pending);
        }




    }
}
