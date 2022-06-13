using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataLayer;


namespace BusinessManager
{
   public  class IPD_Main_DetailsManager
    {
        public static void Add(IPD_Main_Details bgm)
        {
            if (bgm == null)
                throw new ArgumentException("IPD_Main_Details is null.");
            IPD_Main_DetailsDB.Add(bgm);
        }
        public static void Update(IPD_Main_Details bgm)
        {
            if (bgm == null)
                throw new ArgumentException("IPD_Main_Details is null.");
            // if (bgm.Id == null || bgm.Id == default(Guid))
            if (bgm.AdmissionId == null || bgm.AdmissionId == default(Guid))
                throw new ArgumentException("IPD_Main_Details.Id value not set.");
            IPD_Main_DetailsDB.Update(bgm);
        }
        public static void Delete(IPD_Main_Details bgm)
        {
            if (bgm == null)
                throw new ArgumentException("IPD_Main_Details is null.");
            if (bgm.AdmissionId == null || bgm.AdmissionId == default(Guid))
                throw new ArgumentException("IPD_Main_Details.Id value not set.");
            IPD_Main_DetailsDB.Delete(bgm);
        }
        public static IPD_Main_Details GetById(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            IPD_Main_Details bgm = null;
            bgm = IPD_Main_DetailsDB.GetById(id);
            return bgm;
        }
        public static List<IPD_Main_Details> GetAll()
        {
            return IPD_Main_DetailsDB.GetAll();
        }
    }
}
