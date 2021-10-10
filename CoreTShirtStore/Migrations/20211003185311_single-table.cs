using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTShirtStore.Migrations
{
    public partial class singletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sponsors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesRegion = table.Column<int>(type: "int", nullable: true),
                    TShirtID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sponsors_TShirts_TShirtID",
                        column: x => x.TShirtID,
                        principalTable: "TShirts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_TShirtID",
                table: "Sponsors",
                column: "TShirtID");
        }
    }
}
