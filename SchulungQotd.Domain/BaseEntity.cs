using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungQotd.Domain
{
    public class BaseEntity
    {
        //[Key]
        public Guid Id { get; set; }  //Id, ID, Klassenname + Id
    }
}
