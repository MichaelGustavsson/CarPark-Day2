using Microsoft.EntityFrameworkCore.Migrations;

namespace CarParkG2D2.Migrations
{
    public partial class AddedMakeAndModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Make",
                schema: "Vehicles",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Model",
                schema: "Vehicles",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                schema: "Vehicles",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                schema: "Vehicles",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Make",
                schema: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Make", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                schema: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MakeId",
                schema: "Vehicles",
                table: "Vehicle",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ModelId",
                schema: "Vehicles",
                table: "Vehicle",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Make_MakeId",
                schema: "Vehicles",
                table: "Vehicle",
                column: "MakeId",
                principalSchema: "Vehicles",
                principalTable: "Make",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Model_ModelId",
                schema: "Vehicles",
                table: "Vehicle",
                column: "ModelId",
                principalSchema: "Vehicles",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Make_MakeId",
                schema: "Vehicles",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Model_ModelId",
                schema: "Vehicles",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "Make",
                schema: "Vehicles");

            migrationBuilder.DropTable(
                name: "Model",
                schema: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_MakeId",
                schema: "Vehicles",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ModelId",
                schema: "Vehicles",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "MakeId",
                schema: "Vehicles",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ModelId",
                schema: "Vehicles",
                table: "Vehicle");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                schema: "Vehicles",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                schema: "Vehicles",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
