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
                name: "Anggota",
                columns: table => new
                {
                    KodeAnggota = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlamatAnggota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JenisKelamin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pekerjaan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglMasuk = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telepon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempatLahir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglLahir = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anggota", x => x.KodeAnggota);
                });

            migrationBuilder.CreateTable(
                name: "JenisPinjaman",
                columns: table => new
                {
                    KodeJenisPinjaman = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NamaPinjaman = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LamaAngsuran = table.Column<int>(type: "int", nullable: false),
                    MaksPinjaman = table.Column<double>(type: "float", nullable: false),
                    Bunga = table.Column<double>(type: "float", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisPinjaman", x => x.KodeJenisPinjaman);
                });

            migrationBuilder.CreateTable(
                name: "JenisSimpanan",
                columns: table => new
                {
                    KodeJenisSimpanan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NamaSimpanan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BesarSimpanan = table.Column<double>(type: "float", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisSimpanan", x => x.KodeJenisSimpanan);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    KodeUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.KodeUser);
                });

            migrationBuilder.CreateTable(
                name: "Tabungan",
                columns: table => new
                {
                    KodeTabungan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodeAnggota = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TglMulai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BesarTabungan = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabungan", x => x.KodeTabungan);
                    table.ForeignKey(
                        name: "FK_Tabungan_Anggota_KodeAnggota",
                        column: x => x.KodeAnggota,
                        principalTable: "Anggota",
                        principalColumn: "KodeAnggota",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pengajuan",
                columns: table => new
                {
                    KodePengajuan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TglPengajuan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KodeAnggota = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KodeJenisPinjaman = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BesarPinjaman = table.Column<int>(type: "int", nullable: false),
                    TglAcc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pengajuan", x => x.KodePengajuan);
                    table.ForeignKey(
                        name: "FK_Pengajuan_Anggota_KodeAnggota",
                        column: x => x.KodeAnggota,
                        principalTable: "Anggota",
                        principalColumn: "KodeAnggota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pengajuan_JenisPinjaman_KodeJenisPinjaman",
                        column: x => x.KodeJenisPinjaman,
                        principalTable: "JenisPinjaman",
                        principalColumn: "KodeJenisPinjaman",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pinjaman",
                columns: table => new
                {
                    KodePinjaman = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodeJenisPinjaman = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_Pinjaman", x => x.KodePinjaman);
                    table.ForeignKey(
                        name: "FK_Pinjaman_JenisPinjaman_KodeJenisPinjaman",
                        column: x => x.KodeJenisPinjaman,
                        principalTable: "JenisPinjaman",
                        principalColumn: "KodeJenisPinjaman",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Simpanan",
                columns: table => new
                {
                    KodeSimpanan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodeJenisSimpanan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BesarSimpanan = table.Column<double>(type: "float", nullable: false),
                    KodeAnggota = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglMulai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simpanan", x => x.KodeSimpanan);
                    table.ForeignKey(
                        name: "FK_Simpanan_Anggota_KodeAnggota",
                        column: x => x.KodeAnggota,
                        principalTable: "Anggota",
                        principalColumn: "KodeAnggota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Simpanan_JenisPinjaman_KodeJenisSimpanan",
                        column: x => x.KodeJenisSimpanan,
                        principalTable: "JenisPinjaman",
                        principalColumn: "KodeJenisPinjaman",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Penarikan",
                columns: table => new
                {
                    KodePenarikan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodeTabungan = table.Column<int>(type: "int", nullable: false),
                    BesarPenarikan = table.Column<int>(type: "int", nullable: false),
                    TglPenarikan = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penarikan", x => x.KodePenarikan);
                    table.ForeignKey(
                        name: "FK_Penarikan_Tabungan_KodeTabungan",
                        column: x => x.KodeTabungan,
                        principalTable: "Tabungan",
                        principalColumn: "KodeTabungan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Angsuran",
                columns: table => new
                {
                    KodeAngsuran = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodePinjaman = table.Column<int>(type: "int", nullable: false),
                    BesarAngsuran = table.Column<int>(type: "int", nullable: false),
                    Denda = table.Column<int>(type: "int", nullable: false),
                    SisaPinjaman = table.Column<int>(type: "int", nullable: false),
                    KodeAnggota = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserEntry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TglEntry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angsuran", x => x.KodeAngsuran);
                    table.ForeignKey(
                        name: "FK_Angsuran_Anggota_KodeAnggota",
                        column: x => x.KodeAnggota,
                        principalTable: "Anggota",
                        principalColumn: "KodeAnggota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Angsuran_Pinjaman_KodePinjaman",
                        column: x => x.KodePinjaman,
                        principalTable: "Pinjaman",
                        principalColumn: "KodePinjaman",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angsuran_KodeAnggota",
                table: "Angsuran",
                column: "KodeAnggota");

            migrationBuilder.CreateIndex(
                name: "IX_Angsuran_KodePinjaman",
                table: "Angsuran",
                column: "KodePinjaman");

            migrationBuilder.CreateIndex(
                name: "IX_Penarikan_KodeTabungan",
                table: "Penarikan",
                column: "KodeTabungan");

            migrationBuilder.CreateIndex(
                name: "IX_Pengajuan_KodeAnggota",
                table: "Pengajuan",
                column: "KodeAnggota");

            migrationBuilder.CreateIndex(
                name: "IX_Pengajuan_KodeJenisPinjaman",
                table: "Pengajuan",
                column: "KodeJenisPinjaman");

            migrationBuilder.CreateIndex(
                name: "IX_Pinjaman_KodeJenisPinjaman",
                table: "Pinjaman",
                column: "KodeJenisPinjaman");

            migrationBuilder.CreateIndex(
                name: "IX_Simpanan_KodeAnggota",
                table: "Simpanan",
                column: "KodeAnggota");

            migrationBuilder.CreateIndex(
                name: "IX_Simpanan_KodeJenisSimpanan",
                table: "Simpanan",
                column: "KodeJenisSimpanan");

            migrationBuilder.CreateIndex(
                name: "IX_Tabungan_KodeAnggota",
                table: "Tabungan",
                column: "KodeAnggota");
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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Pinjaman");

            migrationBuilder.DropTable(
                name: "Tabungan");

            migrationBuilder.DropTable(
                name: "JenisPinjaman");

            migrationBuilder.DropTable(
                name: "Anggota");
        }
    }
}
