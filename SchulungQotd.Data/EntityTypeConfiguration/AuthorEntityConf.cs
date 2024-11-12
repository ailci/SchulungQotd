using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchulungQotd.Domain;

namespace SchulungQotd.Data.EntityTypeConfiguration
{
    internal class AuthorEntityConf : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Autoren");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            //Name
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(200);

            //Relation
            builder.HasMany(c => c.Quotes).WithOne(c => c.Author);
        }
    }
}
