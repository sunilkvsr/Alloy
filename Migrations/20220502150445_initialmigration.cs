using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alloy.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AR_AREA",
                columns: table => new
                {
                    AR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AR_CODE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AR_FULL_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AR_STATE1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AR_STATE2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AR_STATE3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AR_STATE4 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AR_OLOC_ID = table.Column<int>(type: "int", nullable: true),
                    AR_LEAD_TO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AR_LEAD_CC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AR_GMAP_CLAT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AR_GMAP_CLNG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AR_GMAP_ZOOM = table.Column<int>(type: "int", nullable: true),
                    AR_DIR_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AR_MOVE_IN_PAD_DAYS = table.Column<int>(type: "int", nullable: true),
                    AR_EN_CD = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AR_EN_NM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AR_AREA", x => x.AR_ID);
                });

            migrationBuilder.CreateTable(
                name: "DSC_DESIGN_CENTER",
                columns: table => new
                {
                    DSC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AR_ID = table.Column<int>(type: "int", nullable: false),
                    DSC_ADDRESS1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_ADDRESS2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_CITY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_STATE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_ZIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_PHONE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_DIRECTIONS1_LBL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_DIRECTIONS1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_DIRECTIONS2_LBL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_DIRECTIONS2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_DIRECTIONS3_LBL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_DIRECTIONS3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_HOURS1_LBL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_HOURS1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_HOURS2_LBL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_HOURS2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_LAT = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DSC_LNG = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DSC_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    DSC_HEADLINE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_FILENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DSC_IMAGE = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSC_DESIGN_CENTER", x => x.DSC_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AR_AREA");

            migrationBuilder.DropTable(
                name: "DSC_DESIGN_CENTER");
        }
    }
}
