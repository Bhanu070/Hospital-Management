using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataLayer;


namespace BusinessManager
{
   public  class Service_type_MasterManager
    {
        public static void Add(Service_type_Master bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Service_type_Master is null.");
            Service_type_MasterDB.Add(bgm);
        }
        public static void Update(Service_type_Master bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Service_type_Master is null.");
            // if (bgm.Id == null || bgm.Id == default(Guid))
            if (bgm.ServiceId == null || bgm.ServiceId == default(Guid))
                throw new ArgumentException("Service_type_Master.Id value not set.");
            Service_type_MasterDB.Update(bgm);
        }
        public static void Delete(Service_type_Master bgm)
        {
            if (bgm == null)
                throw new ArgumentException("Service_type_Master is null.");
            if (bgm.ServiceId == null || bgm.ServiceId == default(Guid))
                throw new ArgumentException("Service_type_Master.Id value not set.");
            Service_type_MasterDB.Delete(bgm);
        }
        public static Service_type_Master GetById(Guid id)
        {
            if (id == default(Guid))
                throw new ArgumentException("Id is set to default value.");
            Service_type_Master bgm = null;
            bgm = Service_type_MasterDB.GetById(id);
            return bgm;
        }

        


        public static List<Service_type_Master> GetAll()
        {
            return Service_type_MasterDB.GetAll();
        }
        public static List<Service_type_Master> GetAll_All()
        {
            return Service_type_MasterDB.GetAll_All();
        }

        public static List<Service_type_Master> GetAll_Service(string type)
        {
            return Service_type_MasterDB.GetAll_Service(type);
        }

        public static List<Service_type_Master> GetByServiceType(string ServiceType)
        {
            return Service_type_MasterDB.GetByServiceType(ServiceType);
        }

        public static List<Service_type_Master> GetAll_Service_GetById(string ServiceType,Guid Id)
        {
            return Service_type_MasterDB.GetAll_Service_GetById(ServiceType,Id);
        }

        
    }
}
