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
            // 1. Skapa en ny INT-kolumn
            migrationBuilder.AddColumn<int>(
                name: "NewGenderColumn",
                table: "Customers",
                nullable: true);

            // 2. Konvertera gamla textvärden till siffror
            migrationBuilder.Sql(
                "UPDATE Customers SET NewGenderColumn = " +
                "CASE " +
                "WHEN Gender = 'Male' THEN 1 " +
                "WHEN Gender = 'Female' THEN 2 " +
                "ELSE NULL " +  // Hantera andra värden, eller sätt till 0
                "END");

            // 3. Ta bort den gamla kolumnen
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            // 4. Döp om den nya kolumnen till det gamla namnet
            migrationBuilder.RenameColumn(
                name: "NewGenderColumn",
                table: "Customers",
                newName: "Gender");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Återskapa den gamla nvarchar-kolumnen
            migrationBuilder.AddColumn<string>(
                name: "OldGenderColumn",
                table: "Customers",
                type: "nvarchar(6)",
                nullable: true);

            // Återställ int-värden till text
            migrationBuilder.Sql(
                "UPDATE Customers SET Gender = " +
                "CASE " +
                "WHEN Gender = 1 THEN 'Male' " +
                "WHEN Gender = 2 THEN 'Female' " +
                "ELSE NULL " +
                "END");

            // Ta bort int-kolumnen
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            // Döp om tillbaka
            migrationBuilder.RenameColumn(
                name: "OldGenderColumn",
                table: "Customers",
                newName: "Gender");
        }
    }
}
