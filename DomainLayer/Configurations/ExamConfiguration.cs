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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(e => e.examDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.Score)
                .HasColumnType("numeric(1,0)")
                .IsRequired();
        }
    }
}
