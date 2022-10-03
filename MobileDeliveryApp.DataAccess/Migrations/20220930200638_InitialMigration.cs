using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileDeliveryApp.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaybillInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoadID = table.Column<int>(type: "INTEGER", nullable: true),
                    WaybillID = table.Column<int>(type: "INTEGER", nullable: true),
                    FromLocationID = table.Column<int>(type: "INTEGER", nullable: true),
                    ToLocationID = table.Column<int>(type: "INTEGER", nullable: true),
                    DriverID = table.Column<int>(type: "INTEGER", nullable: true),
                    TrackTypeID = table.Column<int>(type: "INTEGER", nullable: true),
                    LoadStatusID = table.Column<int>(type: "INTEGER", nullable: true),
                    PrimaryLoadID = table.Column<int>(type: "INTEGER", nullable: true),
                    BillCustID = table.Column<int>(type: "INTEGER", nullable: true),
                    ParcelID = table.Column<int>(type: "INTEGER", nullable: true),
                    ScanID = table.Column<string>(type: "TEXT", nullable: true),
                    LoadDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Vehicle = table.Column<string>(type: "TEXT", nullable: true),
                    Courier = table.Column<string>(type: "TEXT", nullable: true),
                    LoadStatus = table.Column<string>(type: "TEXT", nullable: true),
                    WaybillNo = table.Column<string>(type: "TEXT", nullable: true),
                    DriverName = table.Column<string>(type: "TEXT", nullable: true),
                    AllowWaybillScan = table.Column<bool>(type: "INTEGER", nullable: true),
                    TrackType = table.Column<string>(type: "TEXT", nullable: true),
                    ToBC = table.Column<string>(type: "TEXT", nullable: true),
                    Customer = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    PODDate = table.Column<string>(type: "TEXT", nullable: true),
                    Signee = table.Column<string>(type: "TEXT", nullable: true),
                    ScannedDT = table.Column<string>(type: "TEXT", nullable: true),
                    PODUserID = table.Column<string>(type: "TEXT", nullable: true),
                    Signature = table.Column<string>(type: "TEXT", nullable: true),
                    DeliveryType = table.Column<string>(type: "TEXT", nullable: true),
                    Delivered = table.Column<string>(type: "TEXT", nullable: true),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    Completed = table.Column<string>(type: "TEXT", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    Barcode = table.Column<string>(type: "TEXT", nullable: true),
                    ScanDate = table.Column<string>(type: "TEXT", nullable: true),
                    Scanned = table.Column<string>(type: "TEXT", nullable: true),
                    Reason = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    DeviceSerial = table.Column<string>(type: "TEXT", nullable: true),
                    EndorsementID = table.Column<string>(type: "TEXT", nullable: true),
                    Endorsement = table.Column<string>(type: "TEXT", nullable: true),
                    EndorsementTypeID = table.Column<string>(type: "TEXT", nullable: true),
                    Synchronised = table.Column<bool>(type: "INTEGER", nullable: true),
                    Lat = table.Column<decimal>(type: "TEXT", nullable: true),
                    Lng = table.Column<decimal>(type: "TEXT", nullable: true),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: true),
                    WaybillWeight = table.Column<decimal>(type: "TEXT", nullable: true),
                    PL = table.Column<decimal>(type: "TEXT", nullable: true),
                    PW = table.Column<decimal>(type: "TEXT", nullable: true),
                    PH = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaybillInformation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaybillInformation");
        }
    }
}
