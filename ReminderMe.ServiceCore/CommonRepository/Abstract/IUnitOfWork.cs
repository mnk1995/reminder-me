using ReminderMe.ServiceCore.Repository.PrivateDayRepository;
using ReminderMe.ServiceCore.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMe.ServiceCore.CommonRepository.Abstract
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IPrivateDayRepository PrivateDays { get; }
    }
}
