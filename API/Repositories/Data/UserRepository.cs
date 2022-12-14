using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using WebAPI.Context;
using WebAPI.Handlers;
using WebAPI.Models;
using WebAPI.ViewModel;

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

        public int GantiDataAnggota(User user)
        {
            var data = _context.Users.Find(user.IdUser);
            user.Password = data.Password;

            if (data != null)
            {
                _context.Entry(data).State = EntityState.Detached;
                //_context.Update(user);
                _context.Attach(user);
                _context.Entry(user).State = EntityState.Modified;
                //_context.Update(user);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public IEnumerable<UserVM> GetAnggota()
        {
            var data = _context.Users.Where(user => user.IdRole == 3).ToList();
            List<UserVM> result = new List<UserVM>();
            foreach (var item in data)
            {
                result.Add(new UserVM
                {
                    IdUser = item.IdUser,
                    NomorAnggota = item.NomorAnggota,
                    Nama = item.Nama,
                    Email = item.Email,
                    UserName = item.UserName,
                    Alamat = item.Alamat,
                    JenisKelamin = item.JenisKelamin,
                    Pekerjaan = item.Pekerjaan,
                    IdRole = item.IdRole,
                    Telepon = item.Telepon,
                    TempatLahir = item.TempatLahir,
                    TglLahir = item.TglLahir,
                    Status= item.Status,
                    UserEntry = item.UserEntry,
                    TglMasuk = item.TglEntry,
                });
            }
            return result;

        }

        public IEnumerable<UserVM> GetAdminandPetugas()
        {
            var data = _context.Users.Where(user => user.IdRole == 2 || user.IdRole == 1).ToList();
            List<UserVM> result = new List<UserVM>();
            foreach (var item in data)
            {
                result.Add(new UserVM
                {
                    IdUser = item.IdUser,
                    NomorAnggota = item.NomorAnggota,
                    Nama = item.Nama,
                    Email = item.Email,
                    UserName = item.UserName,
                    Alamat = item.Alamat,
                    JenisKelamin = item.JenisKelamin,
                    Pekerjaan = item.Pekerjaan,
                    IdRole = item.IdRole,
                    Telepon = item.Telepon,
                    TempatLahir = item.TempatLahir,
                    TglLahir = item.TglLahir,
                    Status = item.Status,
                    UserEntry = item.UserEntry,
                    TglMasuk = item.TglEntry,
                });
            }
            return result;
        }

        public int ChangeRole(int userId, int idRole)
        {
            var data = _context.Users.Find(userId);
            string nomorBaru = data.NomorAnggota;

            if (idRole == 1)
            {
                data.IdRole = 1;
                nomorBaru = 'U' + nomorBaru.Remove(0, 1);
                data.NomorAnggota = nomorBaru;
                _context.Entry(data).State = EntityState.Modified;
                var result = _context.SaveChanges();
                return result;
            }
            else if (idRole == 2)
            {
                data.IdRole = 2;
                nomorBaru = 'P' + nomorBaru.Remove(0, 1);
                data.NomorAnggota = nomorBaru;
                _context.Entry(data).State = EntityState.Modified;
                var result = _context.SaveChanges();
                return result;
            }
            else
            {
                data.IdRole = 1;
                nomorBaru = 'A' + nomorBaru.Remove(0, 1);
                data.NomorAnggota = nomorBaru;
                _context.Entry(data).State = EntityState.Modified;
                var result = _context.SaveChanges();
                return result;
            }
        }

        public IEnumerable<UserVM> GetAnggotaAktif()
        {
            var data = _context.Users.Where(user => user.IdRole == 3 && user.Status == "Aktif").ToList();

            List<UserVM> result = new List<UserVM>();
            foreach (var item in data)
            {
                result.Add(new UserVM
                {
                    IdUser = item.IdUser,
                    NomorAnggota = item.NomorAnggota,
                    Nama = item.Nama,
                    Email = item.Email,
                    UserName = item.UserName,
                    Alamat = item.Alamat,
                    JenisKelamin = item.JenisKelamin,
                    Pekerjaan = item.Pekerjaan,
                    IdRole = item.IdRole,
                    Telepon = item.Telepon,
                    TempatLahir = item.TempatLahir,
                    TglLahir = item.TglLahir,
                    Status = item.Status,
                    UserEntry = item.UserEntry,
                    TglMasuk = item.TglEntry,
                });
            }
            return result;
        }

        public int TambahAnggota(User user)
        {
            user.Status = "Aktif";
            user.IdRole = 3;
            var data = _context.Users.OrderByDescending(user => user.IdUser).FirstOrDefault(x => x.IdRole.Equals(3));
            if(data == null)
            {
                user.NomorAnggota = 'A' + user.TglLahir.Month.ToString() + user.TglLahir.Year.ToString() + "001";
                user.Password = Hashing.HashPassword(user.NomorAnggota); //DefaultPassword
                _context.Users.Add(user);
                var result = _context.SaveChanges();
                return result;
            }
            else
            {
                string nomorAnggotaBaru = data.NomorAnggota;
                nomorAnggotaBaru = nomorAnggotaBaru.Substring(7);
                int nomorAnggota = 1 + Int32.Parse(nomorAnggotaBaru);
                user.NomorAnggota = 'A' + user.TglLahir.Month.ToString("D2") + user.TglLahir.Year.ToString() + nomorAnggota.ToString("D3");
                user.Password = Hashing.HashPassword(user.NomorAnggota); //DefaultPassword
                _context.Users.Add(user);
                var result = _context.SaveChanges();
                return result;
            }
        }
    }
}
