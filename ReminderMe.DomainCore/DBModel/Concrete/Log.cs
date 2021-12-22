using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMe.DomainCore.DBModel.Concrete
{
    public class Log: Base
    {
        [Required]
        [Column("IpAdres")]
        public string IpAdres { get; set; }

        [Column("LogAciklama")]
        public string LogAciklama { get; set; }

        [Column("ControllerName")]
        public string ControllerName { get; set; }

        [Column("ActionName")]
        public string ActionName { get; set; }
    }
}
