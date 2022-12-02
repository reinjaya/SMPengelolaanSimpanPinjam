using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAPI.Models;

namespace WebAPI.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> context) : base(context)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<JenisPinjaman> JenisPinjaman { get; set; }
        public DbSet<JenisSimpanan> JenisSimpanan { get; set; }
        public DbSet<Tabungan> Tabungan { get; set; }
        public DbSet<Pinjaman> Pinjaman { get; set; }
        public DbSet<Simpanan> Simpanan { get; set; }
        public DbSet<Penarikan> Penarikan { get; set; }
        public DbSet<Pengajuan> Pengajuan { get; set; }
        public DbSet<Angsuran> Angsuran { get; set; }

    }

}
