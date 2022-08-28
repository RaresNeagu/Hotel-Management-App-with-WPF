using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositories
{
    class ServicesRepository
    {
        private readonly Context services;

        public ServicesRepository()
        {
            services = new Context();
        }

        public List<Service> GetServices()
        {
           
            return services.Services.Where(service => service.Deleted == false).ToList();
        }

        public void AddService(string serviceName,int price, bool deleted)
        {
            Service service = new Service
            {
                ServiceName = serviceName,
                PricePerDay = price,
                Deleted = deleted
            };
            services.Services.Add(service);
            services.SaveChanges();
        }

        public void UpdateService(int id, string serviceName, int price, bool deleted)
        {

            var oldService = services.Services.Where(service => service.ServiceId == id).FirstOrDefault();
            if (oldService != null)
            {
                oldService.ServiceName = serviceName;
                oldService.PricePerDay = price;
                oldService.Deleted = deleted;

                services.SaveChanges();
            }
        }

        public void DeleteService(int id, bool deleted)
        {
            var oldService = services.Services.Where(service => service.ServiceId == id).FirstOrDefault();
            if (oldService != null)
            {
                oldService.Deleted = deleted;
                services.SaveChanges();
            }
        }
    }
}
