using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeoverYourCoin.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectDescriptionAndCreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContractAddress",
                table: "ListedProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatorsTwitterLink",
                table: "ListedProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatorsWalletAddress",
                table: "ListedProjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractAddress",
                table: "ListedProjects");

            migrationBuilder.DropColumn(
                name: "CreatorsTwitterLink",
                table: "ListedProjects");

            migrationBuilder.DropColumn(
                name: "CreatorsWalletAddress",
                table: "ListedProjects");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "ListedProjects");
        }
    }
}
