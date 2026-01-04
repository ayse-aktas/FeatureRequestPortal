using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeatureRequestPortal.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVoteWithValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "AppVotes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "AppVotes");
        }
    }
}
