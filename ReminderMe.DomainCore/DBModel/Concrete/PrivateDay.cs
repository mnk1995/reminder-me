using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMe.DomainCore.DBModel.Concrete
{
    public class PrivateDay:Base
    {
        public Guid UserId { get; set; }
        public string PrivateDayName { get; set; }
        public DateTime PrivateDayDate { get; set; }
        public string Description { get; set; }
    }
}
