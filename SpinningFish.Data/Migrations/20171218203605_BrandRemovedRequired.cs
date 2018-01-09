using Microsoft.EntityFrameworkCore.Migrations;

namespace SpinningFish.Data.Migrations
{
    public partial class BrandRemovedRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Brands",
                maxLength: 2097152,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldMaxLength: 2097152);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Brands",
                maxLength: 2097152,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldMaxLength: 2097152,
                oldNullable: true);
        }
    }
}
