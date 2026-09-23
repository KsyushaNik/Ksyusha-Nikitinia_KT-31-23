using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KsyushaNik_kt_31_23.Database.Helpers;
using KsyushaNik_kt_31_23.Models;

namespace KsyushaNik_kt_31_23.Database.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    private const string TableName = "cd_student";

    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable(TableName);

        // Задаем первичный ключ
        builder.HasKey(p => p.StudentId)
            .HasName($"pk_{TableName}_student_id");

        // Для целочисленного первичного ключа задаем автогенерацию
        builder.Property(p => p.StudentId)
            .ValueGeneratedOnAdd();

        // Расписываем колонки в БД
        builder.Property(p => p.StudentId)
            .HasColumnName("student_id")
            .HasComment("Идентификатор записи студента");

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasColumnName("c_student_firstname")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Имя студента");

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasColumnName("c_student_lastname")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Фамилия студента");

        builder.Property(p => p.MiddleName)
            .HasColumnName("c_student_middlename")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Отчество студента");

        builder.Property(p => p.GroupId)
            .IsRequired()
            .HasColumnName("f_group_id")
            .HasColumnType(ColumnType.Int)
            .HasComment("Идентификатор группы");

        // Признак удаления
        builder.Property(p => p.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnName("b_is_deleted")
            .HasColumnType(ColumnType.Bool)
            .HasComment("Признак удаления");

        // Связь один ко многим (одна группа -> много студентов)
        builder.HasOne(p => p.Group)
            .WithMany(t => t.Students)
            .HasForeignKey(p => p.GroupId)
            .HasConstraintName("fk_f_group_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

        // Явная автоподгрузка связанной сущности
        builder.Navigation(p => p.Group)
            .AutoInclude();
    }
}