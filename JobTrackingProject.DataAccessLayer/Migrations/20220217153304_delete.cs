using Microsoft.EntityFrameworkCore.Migrations;

namespace JobTrackingProject.DataAccessLayer.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTechnicians_AspNetUsers_TechnicianId",
                table: "TicketTechnicians");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTechnicians_Tickets_TicketId",
                table: "TicketTechnicians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketTechnicians",
                table: "TicketTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_TicketTechnicians_TechnicianId",
                table: "TicketTechnicians");

            migrationBuilder.RenameTable(
                name: "TicketTechnicians",
                newName: "TicketTechnician");

            migrationBuilder.AddColumn<string>(
                name: "TechnicianId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketTechnician",
                table: "TicketTechnician",
                columns: new[] { "TicketId", "TechnicianId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketTechnician",
                table: "TicketTechnician");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "TicketTechnician",
                newName: "TicketTechnicians");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketTechnicians",
                table: "TicketTechnicians",
                columns: new[] { "TicketId", "TechnicianId" });

            migrationBuilder.CreateIndex(
                name: "IX_TicketTechnicians_TechnicianId",
                table: "TicketTechnicians",
                column: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTechnicians_AspNetUsers_TechnicianId",
                table: "TicketTechnicians",
                column: "TechnicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTechnicians_Tickets_TicketId",
                table: "TicketTechnicians",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
