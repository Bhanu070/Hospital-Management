using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataLayer;


namespace BusinessManager
{
   public  class Service_type_SubDetailsManager
    {
        public static void Add(Service_type_SubDetails bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Service_type_SubDetails is null.");
            Service_type_SubDetailsDB.Add(bgm);
        }

        public static void Add_temp(Service_type_SubDetails bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Service_type_SubDetails is null.");
            Service_type_SubDetailsDB.Add_temp(bgm);
        }

        //public static void Update(Service_type_SubDetails bgm)
        //{
        //    if (bgm == null)
        //        throw new ArgumentException("Service_type_SubDetails is null.");
        //    // if (bgm.Id == null || bgm.Id == default(Guid))
        //    if (bgm.MainId == null || bgm.MainId == default(Guid))
        //        throw new ArgumentException("Service_type_SubDetails.MainId value not set.");
        //    Service_type_SubDetailsDB.Update(bgm);
        //}
        public static Service_type_SubDetails GetById(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            Service_type_SubDetails bgm = null;
            bgm = Service_type_SubDetailsDB.GetById(id);
            return bgm;
        }
        public static Service_type_SubDetails FinalUpdate(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            Service_type_SubDetails bgm = null;
            bgm = Service_type_SubDetailsDB.FinalUpdate(id);
            return bgm;
        }
        public static List<Service_type_SubDetails> GetAll()
        {
            return Service_type_SubDetailsDB.GetAll();
        }
         
    }
}
