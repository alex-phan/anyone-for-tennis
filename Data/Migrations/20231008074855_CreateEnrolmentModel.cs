using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnyoneForTennis.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateEnrolmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnrolmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Enrolment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    CoachId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrolment_AspNetUsers_CoachId",
                        column: x => x.CoachId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrolment_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EnrolmentId",
                table: "AspNetUsers",
                column: "EnrolmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_CoachId",
                table: "Enrolment",
                column: "CoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolment_ScheduleId",
                table: "Enrolment",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Enrolment_EnrolmentId",
                table: "AspNetUsers",
                column: "EnrolmentId",
                principalTable: "Enrolment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Enrolment_EnrolmentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Enrolment");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EnrolmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EnrolmentId",
                table: "AspNetUsers");
        }
    }
}
