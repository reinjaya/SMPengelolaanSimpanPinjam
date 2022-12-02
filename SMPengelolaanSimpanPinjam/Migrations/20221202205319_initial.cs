using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JenisPinjaman",
                columns: table => new
                {
                    IdJenisPinjaman = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaPinjaman = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LamaAngsuran = table.Column<int>(type: "int", nullable: false),
                    MaksPinjaman = table.Column<double>(type: "float", nullable: false),
                    Bunga = table.Column<double>(type: "float", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisPinjaman", x => x.IdJenisPinjaman);
                });

            migrationBuilder.CreateTable(
                name: "JenisSimpanan",
                columns: table => new
                {
                    IdJenisSimpanan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaSimpanan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BesarSimpanan = table.Column<double>(type: "float", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisSimpanan", x => x.IdJenisSimpanan);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomorAnggota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pekerjaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglMasuk = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    Telepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pengajuan",
                columns: table => new
                {
                    IdPengajuan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TglPengajuan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdJenisPinjaman = table.Column<int>(type: "int", nullable: false),
                    BesarPinjaman = table.Column<int>(type: "int", nullable: false),
                    TglAcc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pengajuan", x => x.IdPengajuan);
                    table.ForeignKey(
                        name: "FK_Pengajuan_JenisPinjaman_IdJenisPinjaman",
                        column: x => x.IdJenisPinjaman,
                        principalTable: "JenisPinjaman",
                        principalColumn: "IdJenisPinjaman",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pengajuan_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pinjaman",
                columns: table => new
                {
                    IdPinjaman = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdJenisPinjaman = table.Column<int>(type: "int", nullable: false),
                    BesarPinjaman = table.Column<double>(type: "float", nullable: false),
                    BesarAngsuran = table.Column<double>(type: "float", nullable: false),
                    LamaAngsuran = table.Column<int>(type: "int", nullable: false),
                    SisaAngsuran = table.Column<int>(type: "int", nullable: false),
                    SisaPinjaman = table.Column<double>(type: "float", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TglTempo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pinjaman", x => x.IdPinjaman);
                    table.ForeignKey(
                        name: "FK_Pinjaman_JenisPinjaman_IdJenisPinjaman",
                        column: x => x.IdJenisPinjaman,
                        principalTable: "JenisPinjaman",
                        principalColumn: "IdJenisPinjaman",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pinjaman_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Simpanan",
                columns: table => new
                {
                    IdSimpanan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJenisSimpanan = table.Column<int>(type: "int", nullable: false),
                    BesarSimpanan = table.Column<double>(type: "float", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglMulai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simpanan", x => x.IdSimpanan);
                    table.ForeignKey(
                        name: "FK_Simpanan_JenisPinjaman_IdJenisSimpanan",
                        column: x => x.IdJenisSimpanan,
                        principalTable: "JenisPinjaman",
                        principalColumn: "IdJenisPinjaman",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Simpanan_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tabungan",
                columns: table => new
                {
                    IdTabungan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    TglMulai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BesarTabungan = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabungan", x => x.IdTabungan);
                    table.ForeignKey(
                        name: "FK_Tabungan_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Angsuran",
                columns: table => new
                {
                    IdAngsuran = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPinjaman = table.Column<int>(type: "int", nullable: false),
                    AngsuranKe = table.Column<int>(type: "int", nullable: false),
                    BesarAngsuran = table.Column<int>(type: "int", nullable: false),
                    Denda = table.Column<int>(type: "int", nullable: false),
                    SisaPinjaman = table.Column<int>(type: "int", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angsuran", x => x.IdAngsuran);
                    table.ForeignKey(
                        name: "FK_Angsuran_Pinjaman_IdPinjaman",
                        column: x => x.IdPinjaman,
                        principalTable: "Pinjaman",
                        principalColumn: "IdPinjaman",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penarikan",
                columns: table => new
                {
                    IdPenarikan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTabungan = table.Column<int>(type: "int", nullable: false),
                    BesarPenarikan = table.Column<int>(type: "int", nullable: false),
                    TglPenarikan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penarikan", x => x.IdPenarikan);
                    table.ForeignKey(
                        name: "FK_Penarikan_Tabungan_IdTabungan",
                        column: x => x.IdTabungan,
                        principalTable: "Tabungan",
                        principalColumn: "IdTabungan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angsuran_IdPinjaman",
                table: "Angsuran",
                column: "IdPinjaman");

            migrationBuilder.CreateIndex(
                name: "IX_Penarikan_IdTabungan",
                table: "Penarikan",
                column: "IdTabungan");

            migrationBuilder.CreateIndex(
                name: "IX_Pengajuan_IdJenisPinjaman",
                table: "Pengajuan",
                column: "IdJenisPinjaman");

            migrationBuilder.CreateIndex(
                name: "IX_Pengajuan_IdUser",
                table: "Pengajuan",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Pinjaman_IdJenisPinjaman",
                table: "Pinjaman",
                column: "IdJenisPinjaman");

            migrationBuilder.CreateIndex(
                name: "IX_Pinjaman_IdUser",
                table: "Pinjaman",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Simpanan_IdJenisSimpanan",
                table: "Simpanan",
                column: "IdJenisSimpanan");

            migrationBuilder.CreateIndex(
                name: "IX_Simpanan_IdUser",
                table: "Simpanan",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Tabungan_IdUser",
                table: "Tabungan",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Angsuran");

            migrationBuilder.DropTable(
                name: "JenisSimpanan");

            migrationBuilder.DropTable(
                name: "Penarikan");

            migrationBuilder.DropTable(
                name: "Pengajuan");

            migrationBuilder.DropTable(
                name: "Simpanan");

            migrationBuilder.DropTable(
                name: "Pinjaman");

            migrationBuilder.DropTable(
                name: "Tabungan");

            migrationBuilder.DropTable(
                name: "JenisPinjaman");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
