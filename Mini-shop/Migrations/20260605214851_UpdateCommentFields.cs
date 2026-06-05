using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_shop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminReply",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminReply",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Comment");
        }
    }
}
