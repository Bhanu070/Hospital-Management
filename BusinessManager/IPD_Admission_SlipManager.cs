using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataLayer;


namespace BusinessManager
{
   public  class IPD_Admission_SlipManager
    {
        public static void Add(IPD_Admission_Slip bgm)
        {
            if (bgm == null)
                throw new ArgumentException("IPD_Admission_Slip is null.");
            IPD_Admission_SlipDB.Add(bgm);
        }
        public static void Update(IPD_Admission_Slip bgm)
        {
            if (bgm == null)
                throw new ArgumentException("IPD_Admission_Slip is null.");
            // if (bgm.Id == null || bgm.Id == default(Guid))
            if (bgm.AdmissionId == null || bgm.AdmissionId == default(Guid))
                throw new ArgumentException("IPD_Admission_Slip.Id value not set.");
            IPD_Admission_SlipDB.Update(bgm);
        }
        public static void Delete(IPD_Admission_Slip bgm)
        {
            if (bgm == null)
                throw new ArgumentException("IPD_Admission_Slip is null.");
            if (bgm.AdmissionId == null || bgm.AdmissionId == default(Guid))
                throw new ArgumentException("IPD_Admission_Slip.Id value not set.");
            IPD_Admission_SlipDB.Delete(bgm);
        }
        public static IPD_Admission_Slip GetById(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            IPD_Admission_Slip bgm = null;
            bgm = IPD_Admission_SlipDB.GetById(id);
            return bgm;
        }
        public static List<IPD_Admission_Slip> GetAll()
        {
            return IPD_Admission_SlipDB.GetAll();
        }
    }
}
