using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransactionView.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin_transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    cec_client_id = table.Column<int>(type: "int", nullable: false),
                    transaction_by = table.Column<int>(type: "int", nullable: false),
                    transaction_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    changed_value = table.Column<int>(type: "int", nullable: true),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    changed_to = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    policy_reference = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_transactions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cec_employee",
                columns: table => new
                {
                    CecEmployeeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cec_employee", x => x.CecEmployeeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_transactions");

            migrationBuilder.DropTable(
                name: "cec_employee");
        }
    }
}
