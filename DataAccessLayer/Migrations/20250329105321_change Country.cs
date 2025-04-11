using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changeCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewCountryColumn",
                table: "Customers",
                nullable: true);

            migrationBuilder.Sql(
                "UPDATE Customers SET NewCountryColumn = " +
                "CASE " +
                "WHEN Country = 'Sweden' THEN 1 " +
                "WHEN Country = 'Denmark' THEN 2 " +
                "WHEN Country = 'Norway' THEN 3 " +
                "WHEN Country = 'Finland' THEN 4 " +
                "ELSE NULL " +
                "END");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "NewCountryColumn",
                table: "Customers",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OldCountryColumn",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.Sql(
                "UPDATE Customers SET OldCountryColumn = " +
                "CASE " +
                "WHEN Country = 1 THEN 'Sweden' " +
                "WHEN Country = 2 THEN 'Denmark' " +
                "WHEN Country = 3 THEN 'Norway' " +
                "WHEN Country = 4 THEN 'Finland' " +
                "ELSE NULL " +
                "END");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "OldCountryColumn",
                table: "Customers",
                newName: "Country");
        }
    }
}
