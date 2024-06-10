using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liberation.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNoteModelTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "NoteModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteModels",
                table: "NoteModels",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteModels",
                table: "NoteModels");

            migrationBuilder.RenameTable(
                name: "NoteModels",
                newName: "Note");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "Id");
        }
    }
}
