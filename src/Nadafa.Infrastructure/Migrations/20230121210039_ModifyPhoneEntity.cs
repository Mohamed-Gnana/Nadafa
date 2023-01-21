using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nadafa.Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPhoneEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                schema: "UserSchema",
                table: "Phones",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                schema: "UserSchema",
                table: "Phones");
        }
    }
}
