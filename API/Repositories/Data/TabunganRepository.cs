using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI.Context;
using WebAPI.Handlers;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Repositories.Data
{
    public class TabunganRepository : GeneralRepository<Tabungan>
    {
        private MyContext _context;
        public TabunganRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<TabunganAnggota> GetDaftarTabungan()
        {
            var data = _context.Tabungan.Include(u => u.User).ToList();

            List<TabunganAnggota> result = new List<TabunganAnggota>();

            foreach (var item in data)
            {
                if(item.User.Status == "Aktif")
                {
                    result.Add(new TabunganAnggota
                    {
                        IdUser = item.IdUser,
                        IdTabungan = item.IdTabungan,
                        NomorAnggota = item.User.NomorAnggota,
                        NamaAnggota = item.User.Nama,
                        TglMulai = item.TglMulai,
                        JumlahSaldo = item.BesarTabungan
                    });
                }
            }
            return result;
        }

        public int PenarikanUang(int id, double uang)
        {
            var data = _context.Tabungan.SingleOrDefault(x => x.IdUser.Equals(id));
            bool sisaSaldo = data.BesarTabungan - uang > 50000;
            if (!sisaSaldo)
            {
                return 3;
            }

            else if (data != null && sisaSaldo)
            {
                Penarikan penarikan = new Penarikan()
                {
                    IdTabungan = data.IdTabungan,
                    BesarPenarikan = (int)uang,
                    TglPenarikan = DateTime.Now
                };

                data.BesarTabungan -= uang;
                _context.Entry(data).State = EntityState.Modified;
                _context.Penarikan.Add(penarikan);
                var result = _context.SaveChanges();
                return result;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<Penarikan> GetRiwayatPenarikan(int idUser)
        {
            return _context.Penarikan.Include(x => x.Tabungan).Where(x => x.Tabungan.IdUser == idUser).ToList();
        }

        public double TotalTabungan()
        {
            double sum = _context.Tabungan.Select(t => t.BesarTabungan).Sum();
            return sum;
        }
    }
}
