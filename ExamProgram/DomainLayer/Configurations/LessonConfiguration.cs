using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace DomainLayer.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasIndex(l => l.Code)
                   .IsUnique();

            builder.Property(l => l.Code)
                .HasColumnType("char(3)")
                .IsRequired();

            builder.Property(l => l.lessonName)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(l => l.teacherName)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(l => l.teacherSurname)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(l => l.Grade)
                .HasColumnType("numeric(2,0)")
                .IsRequired();


            builder.HasOne(l => l.Exam)
                .WithOne(e => e.Lesson)
                .HasForeignKey<Exam>(l => l.LessonId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
