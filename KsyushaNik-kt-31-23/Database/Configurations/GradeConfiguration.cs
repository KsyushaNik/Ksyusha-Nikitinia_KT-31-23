using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KsyushaNik_kt_31_23.Database.Helpers;
using KsyushaNik_kt_31_23.Models;

namespace KsyushaNik_kt_31_23.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        private const string TableName = "cd_grade";

        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(t => t.GradeId)
                .HasName($"pk_{TableName}_grade_id");

            builder.Property(p => p.GradeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("grade_id")
                .HasComment("Идентификатор оценки");

            builder.Property(p => p.Value)
                .IsRequired()
                .HasColumnName("c_grade_value")
                .HasColumnType(ColumnType.Int)
                .HasComment("Значение оценки");

            builder.Property(p => p.StudentId)
                .IsRequired()
                .HasColumnName("f_student_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор студента");

            builder.Property(p => p.DisciplineId)
                .IsRequired()
                .HasColumnName("f_discipline_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор дисциплины");

            // Связь со студентом
            builder.HasOne(p => p.Student)
                .WithMany(t => t.Grades)
                .HasForeignKey(p => p.StudentId)
                .HasConstraintName($"fk_{TableName}_student_id")
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с дисциплиной
            builder.HasOne(p => p.Discipline)
                .WithMany(t => t.Grades)
                .HasForeignKey(p => p.DisciplineId)
                .HasConstraintName($"fk_{TableName}_discipline_id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}