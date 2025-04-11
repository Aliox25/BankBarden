using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changeGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("ALTER TABLE Customers DROP CONSTRAINT CK_Customers;");

            migrationBuilder.AddColumn<int>(
                name: "NewGenderColumn",
                table: "Customers",
                nullable: true);

            migrationBuilder.Sql(
                "UPDATE Customers SET NewGenderColumn = " +
                "CASE " +
                "WHEN Gender = 'Male' THEN 1 " +
                "WHEN Gender = 'Female' THEN 2 " +
                "ELSE NULL " +
                "END");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "NewGenderColumn",
                table: "Customers",
                newName: "Gender");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OldGenderColumn",
                table: "Customers",
                type: "nvarchar(6)",
                nullable: true);

            migrationBuilder.Sql(
                "UPDATE Customers SET Gender = " +
                "CASE " +
                "WHEN Gender = 1 THEN 'Male' " +
                "WHEN Gender = 2 THEN 'Female' " +
                "ELSE NULL " +
                "END");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "OldGenderColumn",
                table: "Customers",
                newName: "Gender");
        }
    }
}
