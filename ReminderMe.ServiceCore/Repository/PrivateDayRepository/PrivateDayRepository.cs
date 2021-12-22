using ReminderMe.DomainCore.DBModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Transactions;
using ReminderMe.ServiceCore.CommonRepository;
using ReminderMe.ServiceCore.CommonRepository.Concrete;
using ReminderMe.DomainCore.DBModel.Concrete;

namespace ReminderMe.ServiceCore.Repository.PrivateDayRepository
{
    public class PrivateDayRepository : GenericRepository<PrivateDay>, IPrivateDayRepository
    {
        public PrivateDayRepository(IConfiguration configuration):base(configuration)
        {

        }
    }

}
