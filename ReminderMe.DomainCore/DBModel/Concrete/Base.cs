using ReminderMe.DomainCore.DBModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderMe.DomainCore.DBModel
{
    public class Base:IBase
    {

        [Column("Id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("DateCreated")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Column("DateModified")]
        public DateTime DateModified { get; set; } = DateTime.Now;

        [Column("UserCreated")]
        public Guid? UserCreated { get; set; } = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971");


        [Column("UserModified")]
        public Guid? UserModified { get; set; } = Guid.Parse("1FCC262D-5EA7-4BA6-890B-681AC0886971");

        [Column("IsActive")]
        public bool IsActive { get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
