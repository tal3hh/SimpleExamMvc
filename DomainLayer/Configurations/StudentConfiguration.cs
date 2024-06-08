using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasIndex(l => l.Number)
                   .IsUnique();

            builder.Property(s => s.Number)
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(s => s.firstName)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(s => s.lastName)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(s => s.Grade)
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.HasOne(s => s.Exam)
                .WithOne(e => e.Student)
                .HasForeignKey<Exam>(e => e.StudentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
