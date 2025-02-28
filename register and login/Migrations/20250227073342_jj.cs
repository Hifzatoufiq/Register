using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace register_and_login.Migrations
{
    /// <inheritdoc />
    public partial class jj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "product1",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_product1_CategoryId",
                table: "product1",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_product1_category_CategoryId",
                table: "product1",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product1_category_CategoryId",
                table: "product1");

            migrationBuilder.DropIndex(
                name: "IX_product1_CategoryId",
                table: "product1");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "product1");
        }
    }
}
