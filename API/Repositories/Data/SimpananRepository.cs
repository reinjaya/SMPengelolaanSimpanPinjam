using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Repositories.Data
{
    public class SimpananRepository : GeneralRepository<Simpanan>
    {
        private MyContext _context;
        public SimpananRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Simpanan> DaftarSimpananAnggota(int idUser)
        {
            return _context.Simpanan.Where(x => x.IdUser == idUser).ToList();
        }

        public int TambahSimpananWajib(int idUser, string userEntry)
        {
            bool cek = CekTglWajib(idUser);
            if (cek)
            {
                var data = _context.JenisSimpanan.Find(2); //Id Simpanan Wajib
                Simpanan simpanan = new Simpanan()
                {
                    IdSimpanan = 0,
                    BesarSimpanan = data.BesarSimpanan,
                    IdJenisSimpanan = data.IdJenisSimpanan,
                    IdUser = idUser,
                    UserEntry = userEntry,
                    TglMulai = DateTime.Now,
                    TglEntry = DateTime.Now,
                };

                var dataTabungan = _context.Tabungan.SingleOrDefault(x => x.IdUser.Equals(idUser));
                dataTabungan.BesarTabungan += data.BesarSimpanan;
                _context.Entry(dataTabungan).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Simpanan.Add(simpanan);
                var result = _context.SaveChanges();
                return result;
            }

            else
            {
                return 3;
            }

        }

        public int TambahSimpananSukarela(int idUser, int jumlahUang, string userEntry)
        {
            var data = _context.JenisSimpanan.Find(3); //Id Simpanan Sukarela
            Simpanan simpanan = new Simpanan()
            {
                IdSimpanan = 0,
                BesarSimpanan = jumlahUang,
                IdJenisSimpanan = data.IdJenisSimpanan,
                IdUser = idUser,
                UserEntry = userEntry,
                TglMulai = DateTime.Now,
                TglEntry = DateTime.Now,
            };

            var dataTabungan = _context.Tabungan.SingleOrDefault(x => x.IdUser.Equals(idUser));
            dataTabungan.BesarTabungan += jumlahUang;
            _context.Entry(dataTabungan).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Simpanan.Add(simpanan);
            var result = _context.SaveChanges();
            return result;
        }

        public bool CekTglWajib(int idUser)
        {
            var data = _context.Simpanan.OrderByDescending(simpanan => simpanan.IdSimpanan).FirstOrDefault(x => x.IdUser.Equals(idUser) && x.JenisSimpanan.IdJenisSimpanan.Equals(2));

            if (data == null)
            {
                return true;
            }
            else
            {
                double tglTerakhir = (DateTime.Now - data.TglMulai).TotalHours;
                if (tglTerakhir < 720)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }

        }
    }
}
