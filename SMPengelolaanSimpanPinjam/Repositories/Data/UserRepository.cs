using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using WebAPI.Context;
using WebAPI.Handlers;
using WebAPI.Models;

namespace WebAPI.Repositories.Data
{
    public class UserRepository : GeneralRepository<User>
    {
        private MyContext _context;
        public UserRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        //Menambahkan simpanan pokok dan saldo tabungan setelah menambahkan anggota
        public int AddSaldo(int idUser, string userEntry, DateTime tglMulai, DateTime tglEntry)
        {
            var data = _context.JenisSimpanan.Find(1); //Id Pokok
            Simpanan simpanan = new Simpanan()
            {
                IdSimpanan = 0,
                BesarSimpanan = data.BesarSimpanan, //Simpanan Pokok
                IdJenisSimpanan = 1, //Simpanan Pokok
                IdUser = idUser,
                UserEntry = userEntry,
                TglMulai = tglMulai,
                TglEntry = tglEntry
            };

            Tabungan tabungan = new Tabungan()
            {
                IdUser = idUser,
                TglMulai = tglMulai,
                BesarTabungan = data.BesarSimpanan
            };

            _context.Simpanan.Add(simpanan);
            _context.Tabungan.Add(tabungan);
            var result = _context.SaveChanges();
            return result;
        }

        public int GantiStatusAnggota(int id, bool keluarkan)
        {
            var data = _context.Users.Find(id);
            if (data == null)
            {
                data.Status = "Aktif";
                if (keluarkan)
                {
                    data.Status = "Keluar";
                }

                _context.Entry(data).State = EntityState.Modified;
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public int GantiPassword(int id, string newPassword)
        {
            var data = _context.Users.Find(id);
            if (data != null)
            {
                data.Password = Hashing.HashPassword(newPassword);
                _context.Entry(data).State = EntityState.Modified;
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public IEnumerable<User> GetAnggota()
        {
            return _context.Users.Where(user => user.IdRole == 3).ToList();
        }
        public IEnumerable<User> GetAnggotaAktif()
        {
            return _context.Users.Where(user => user.IdRole == 3 && user.Status == "Aktif").ToList();
        }

    }
}
