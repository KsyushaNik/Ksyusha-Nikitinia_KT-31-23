using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KsyushaNik_kt_31_23.Database.Helpers;
using KsyushaNik_kt_31_23.Models;

namespace KsyushaNik_kt_31_23.Database.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    private const string TableName = "cd_group";

    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable(TableName);

        // Первичный ключ
        builder.HasKey(p => p.GroupId)
            .HasName($"pk_{TableName}_group_id");

        builder.Property(p => p.GroupId)
            .ValueGeneratedOnAdd()
            .HasColumnName("group_id")
            .HasComment("Идентификатор записи группы");

        // Название группы
        builder.Property(p => p.GroupName)
            .IsRequired()
            .HasColumnName("c_group_name")
            .HasColumnType(ColumnType.String)
            .HasMaxLength(100)
            .HasComment("Название группы");

        // Курс
        builder.Property(p => p.Course)
            .IsRequired()
            .HasDefaultValue(1)
            .HasColumnName("c_group_course")
            .HasColumnType(ColumnType.Int)
            .HasComment("Курс");

        // Признак удаления
        builder.Property(p => p.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnName("b_is_deleted")
            .HasColumnType(ColumnType.Bool)
            .HasComment("Признак удаления");

        // Внешний ключ на специальность
        builder.Property(p => p.SpecialtyId)
            .HasColumnName("f_specialty_id")
            .HasColumnType(ColumnType.Int)
            .HasComment("Идентификатор специальности");

        // Связь со специальностью (Specialty 1 -> N Groups)
        builder.HasOne(p => p.Specialty)
            .WithMany(t => t.Groups)
            .HasForeignKey(p => p.SpecialtyId)
            .HasConstraintName($"fk_{TableName}_specialty_id")
            .OnDelete(DeleteBehavior.SetNull);
    }
}