using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changeFrequency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Accounts DROP CONSTRAINT CK_Accounts_Frequency;");

            migrationBuilder.AddColumn<int>(
                name: "NewFrequencyColumn",
                table: "Accounts",
                nullable: true);

            migrationBuilder.Sql(
                "UPDATE Accounts SET NewFrequencyColumn = " +
                "CASE " +
                "WHEN Frequency = 'AfterTransaction' THEN 1 " +
                "WHEN Frequency = 'Daily' THEN 2 " +
                "WHEN Frequency = 'Weekly' THEN 3 " +
                "WHEN Frequency = 'Monthly' THEN 4 " +
                "END");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "NewFrequencyColumn",
                table: "Accounts",
                newName: "Frequency");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OldFrequencyColumn",
                table: "Accounts",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.Sql(
                "UPDATE Accounts SET OldFrequencyColumn = " +
                "CASE " +
                "WHEN Frequency = 1 THEN 'AfterTransaction'" +
                "WHEN Frequency = 2 THEN 'Daily'" +
                "WHEN Frequency = 3 THEN 'Weekly'" +
                "WHEN Frequency = 4 THEN 'Monthly'" +
                "ELSE NULL " +
                "END");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "OldFrequencyColumn",
                table: "Accounts",
                newName: "Frequency");

        }
    }
}
