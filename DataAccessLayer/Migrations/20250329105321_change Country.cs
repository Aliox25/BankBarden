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
            // 1. Skapa en ny INT-kolumn
            migrationBuilder.AddColumn<int>(
                name: "NewCountryColumn",
                table: "Customers",
                nullable: true);

            // 2. Konvertera gamla textvärden till siffror
            migrationBuilder.Sql(
                "UPDATE Customers SET NewCountryColumn = " +
                "CASE " +
                "WHEN Country = 'Sweden' THEN 1 " +
                "WHEN Country = 'Denmark' THEN 2 " +
                "WHEN Country = 'Norway' THEN 3 " +
                "WHEN Country = 'Finland' THEN 4 " +
                "ELSE NULL " +  // Hantera andra värden, eller sätt till 0
                "END");

            // 3. Ta bort den gamla kolumnen
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            // 4. Döp om den nya kolumnen till det gamla namnet
            migrationBuilder.RenameColumn(
                name: "NewCountryColumn",
                table: "Customers",
                newName: "Country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Återskapa den gamla nvarchar-kolumnen
            migrationBuilder.AddColumn<string>(
                name: "OldCountryColumn",
                table: "Customers",
                type: "nvarchar(100)",
                nullable: true);

            // Återställ int-värden till text
            migrationBuilder.Sql(
                "UPDATE Customers SET Gender = " +
                "CASE " +
                "WHEN Country = 1 THEN 'Sweden' " +
                "WHEN Country = 2 THEN 'Denmark' " +
                "WHEN Country = 3 THEN 'Norway' " +
                "WHEN Country = 4' THEN 'Finland' " +
                "ELSE NULL " +
                "END");

            // Ta bort int-kolumnen
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            // Döp om tillbaka
            migrationBuilder.RenameColumn(
                name: "OldCountryColumn",
                table: "Customers",
                newName: "Country");
        }
    }
}
