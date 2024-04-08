using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart.Meters.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "F33KV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F33KV", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Seal = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    InstallationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "F11KV",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    F33KVID = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_F11KV", x => x.ID);
                    table.ForeignKey(
                        name: "FK_F11KV_F33KV_F33KVID",
                        column: x => x.F33KVID,
                        principalTable: "F33KV",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeterID = table.Column<int>(type: "INTEGER", nullable: false),
                    IP = table.Column<string>(type: "TEXT", nullable: false),
                    Port = table.Column<string>(type: "TEXT", nullable: false),
                    SimCardNumber = table.Column<string>(type: "TEXT", nullable: false),
                    HDLC_Address = table.Column<string>(type: "TEXT", nullable: false),
                    LinkLayerProtocol = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicationLayerProtocol = table.Column<int>(type: "INTEGER", nullable: false),
                    TransmissionMode = table.Column<string>(type: "TEXT", nullable: false),
                    MeterRemoteMode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Profile_Meter_MeterID",
                        column: x => x.MeterID,
                        principalTable: "Meter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reading",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeterID = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalImpActiveEnergy = table.Column<double>(type: "REAL", nullable: false),
                    ImpActiveEnergyT1 = table.Column<double>(type: "REAL", nullable: false),
                    ImpActiveEnergyT2 = table.Column<double>(type: "REAL", nullable: false),
                    ImpActiveEnergyT3 = table.Column<double>(type: "REAL", nullable: false),
                    ImpActiveEnergyT4 = table.Column<double>(type: "REAL", nullable: false),
                    TotalExpActiveEnergy = table.Column<double>(type: "REAL", nullable: false),
                    ExpActiveEnergyT1 = table.Column<double>(type: "REAL", nullable: false),
                    ExpActiveEnergyT2 = table.Column<double>(type: "REAL", nullable: false),
                    ExpActiveEnergyT3 = table.Column<double>(type: "REAL", nullable: false),
                    ExpActiveEnergyT4 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reading", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reading_Meter_MeterID",
                        column: x => x.MeterID,
                        principalTable: "Meter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transformer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    F11KVID = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transformer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transformer_F11KV_F11KVID",
                        column: x => x.F11KVID,
                        principalTable: "F11KV",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    TransformerID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customer_Transformer_TransformerID",
                        column: x => x.TransformerID,
                        principalTable: "Transformer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TransformerID",
                table: "Customer",
                column: "TransformerID");

            migrationBuilder.CreateIndex(
                name: "IX_F11KV_F33KVID",
                table: "F11KV",
                column: "F33KVID");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_MeterID",
                table: "Profile",
                column: "MeterID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reading_MeterID",
                table: "Reading",
                column: "MeterID");

            migrationBuilder.CreateIndex(
                name: "IX_Transformer_F11KVID",
                table: "Transformer",
                column: "F11KVID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Reading");

            migrationBuilder.DropTable(
                name: "Transformer");

            migrationBuilder.DropTable(
                name: "Meter");

            migrationBuilder.DropTable(
                name: "F11KV");

            migrationBuilder.DropTable(
                name: "F33KV");
        }
    }
}
