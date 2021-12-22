using ReminderMe.ServiceCore.CommonRepository.Abstract;
using ReminderMe.ServiceCore.Repository.PrivateDayRepository;
using ReminderMe.ServiceCore.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMe.ServiceCore.CommonRepository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get;}
        public IPrivateDayRepository PrivateDays { get;}
        public UnitOfWork(IUserRepository userRepository, IPrivateDayRepository privateDayRepository)
        {
            Users = userRepository;
            PrivateDays = privateDayRepository;
        }

    }
}
