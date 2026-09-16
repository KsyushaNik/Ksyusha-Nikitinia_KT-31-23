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

        builder.HasKey(p => p.GroupId)
            .HasName($"pk_{TableName}_group_id");

        builder.Property(p => p.GroupId)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.GroupId)
            .HasColumnName("group_id")
            .HasComment("Идентификатор записи группы");

        builder.Property(p => p.GroupName)
            .IsRequired()
            .HasColumnName("c_group_name")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Название группы");
    }
}