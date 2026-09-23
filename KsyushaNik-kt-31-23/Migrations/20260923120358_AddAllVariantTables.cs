using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KsyushaNik_kt_31_23.Migrations
{
    /// <inheritdoc />
    public partial class AddAllVariantTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "c_student_middlename",
                table: "cd_student",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Отчество студента",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Отчество студента");

            migrationBuilder.AddColumn<bool>(
                name: "b_is_deleted",
                table: "cd_student",
                type: "bool",
                nullable: false,
                defaultValue: false,
                comment: "Признак удаления");

            migrationBuilder.AddColumn<bool>(
                name: "b_is_deleted",
                table: "cd_group",
                type: "bool",
                nullable: false,
                defaultValue: false,
                comment: "Признак удаления");

            migrationBuilder.AddColumn<int>(
                name: "c_group_course",
                table: "cd_group",
                type: "int4",
                nullable: false,
                defaultValue: 1,
                comment: "Курс");

            migrationBuilder.AddColumn<int>(
                name: "f_specialty_id",
                table: "cd_group",
                type: "int4",
                nullable: true,
                comment: "Идентификатор специальности");

            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_name = table.Column<string>(type: "varchar", maxLength: 150, nullable: false, comment: "Название дисциплины"),
                    b_is_deleted = table.Column<bool>(type: "bool", nullable: false, defaultValue: false, comment: "Признак удаления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_specialty",
                columns: table => new
                {
                    specialty_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор специальности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_specialty_title = table.Column<string>(type: "varchar", maxLength: 150, nullable: false, comment: "Название специальности"),
                    c_specialty_code = table.Column<string>(type: "varchar", maxLength: 20, nullable: false, comment: "Код специальности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_specialty_specialty_id", x => x.specialty_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_grade",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор оценки")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_grade_value = table.Column<int>(type: "int4", nullable: false, comment: "Значение оценки"),
                    f_student_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор студента"),
                    f_discipline_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_grade_grade_id", x => x.grade_id);
                    table.ForeignKey(
                        name: "fk_cd_grade_discipline_id",
                        column: x => x.f_discipline_id,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cd_grade_student_id",
                        column: x => x.f_student_id,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_group_f_specialty_id",
                table: "cd_group",
                column: "f_specialty_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_grade_f_discipline_id",
                table: "cd_grade",
                column: "f_discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_grade_f_student_id",
                table: "cd_grade",
                column: "f_student_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cd_group_specialty_id",
                table: "cd_group",
                column: "f_specialty_id",
                principalTable: "cd_specialty",
                principalColumn: "specialty_id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cd_group_specialty_id",
                table: "cd_group");

            migrationBuilder.DropTable(
                name: "cd_grade");

            migrationBuilder.DropTable(
                name: "cd_specialty");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropIndex(
                name: "IX_cd_group_f_specialty_id",
                table: "cd_group");

            migrationBuilder.DropColumn(
                name: "b_is_deleted",
                table: "cd_student");

            migrationBuilder.DropColumn(
                name: "b_is_deleted",
                table: "cd_group");

            migrationBuilder.DropColumn(
                name: "c_group_course",
                table: "cd_group");

            migrationBuilder.DropColumn(
                name: "f_specialty_id",
                table: "cd_group");

            migrationBuilder.AlterColumn<string>(
                name: "c_student_middlename",
                table: "cd_student",
                type: "varchar",
                maxLength: 100,
                nullable: true,
                comment: "Отчество студента",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldComment: "Отчество студента");
        }
    }
}
