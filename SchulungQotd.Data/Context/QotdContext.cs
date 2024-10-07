using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchulungQotd.Domain;

namespace SchulungQotd.Data.Context
{
    public class QotdContext : DbContext
    {
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Quote> Quotes => Set<Quote>();

        public QotdContext(DbContextOptions<QotdContext> options) : base(options)
        {
            
        }
    }
}
