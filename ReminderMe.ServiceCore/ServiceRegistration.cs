using ReminderMe.ServiceCore.CommonRepository;
using ReminderMe.ServiceCore.CommonRepository.Abstract;
using ReminderMe.ServiceCore.CommonRepository.Concrete;
using ReminderMe.ServiceCore.Repository.UserRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReminderMe.ServiceCore.Repository.PrivateDayRepository;

namespace ReminderMe.ServiceCore
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPrivateDayRepository, PrivateDayRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
