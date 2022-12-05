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
            if (data != null)
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

        public int TambahAnggota(User user)
        {
            user.Status = "Aktif";
            var data = _context.Users.OrderByDescending(user => user.IdUser).FirstOrDefault(x => x.IdRole.Equals(3));
            if(data == null)
            {
                user.NomorAnggota = 'A' + user.TglLahir.Month.ToString() + user.TglLahir.Year.ToString() + "0001";
                user.Password = user.NomorAnggota; //DefaultPassword
                _context.Users.Add(user);
                var result = _context.SaveChanges();
                return result;
            }
            else
            {
                string nomorAnggotaBaru = data.NomorAnggota;
                nomorAnggotaBaru = nomorAnggotaBaru.Substring(7);
                int nomorAnggota = 1 + Int32.Parse(nomorAnggotaBaru);
                user.NomorAnggota = 'A' + user.TglLahir.Month.ToString() + user.TglLahir.Year.ToString() + nomorAnggota.ToString("D3");
                user.Password = user.NomorAnggota; //DefaultPassword
                _context.Users.Add(user);
                var result = _context.SaveChanges();
                return result;
            }
 
        }

    }
}
