﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungQotd.Domain
{
    public class Quote : BaseEntity
    {
        public required string QuoteText { get; set; }

        //[ForeignKey("PommeCurrywurst")]
        public Author Author { get; set; }
        public Guid AuthorId { get; set; } // Ursprungsklasse + Id
    }
}
