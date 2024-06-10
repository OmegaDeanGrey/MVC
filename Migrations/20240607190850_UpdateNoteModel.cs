using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liberation.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNoteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteModels",
                table: "NoteModels");

            migrationBuilder.RenameTable(
                name: "NoteModels",
                newName: "Notes");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Notes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "NoteModels");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "NoteModels",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteModels",
                table: "NoteModels",
                column: "Id");
        }
    }
}
