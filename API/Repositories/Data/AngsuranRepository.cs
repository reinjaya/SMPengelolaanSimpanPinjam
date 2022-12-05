using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Repositories.Data
{
    public class AngsuranRepository : GeneralRepository<Angsuran>
    {
        private MyContext _context;
        public AngsuranRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public double HitungDenda(DateTime TglTempo )
        {
            double lewatJatuhTempo = Math.Floor((DateTime.Now - TglTempo).TotalHours / 24);
            if(lewatJatuhTempo > 0)
            {
                double denda = lewatJatuhTempo * 10000;
                return denda;
            }
            else
            {
                return 0;
            }
        }

        public int TambahAngsuranPinjaman(int idPinjaman, string userEntry)
        {
            var data = _context.Pinjaman.SingleOrDefault(x => x.IdPinjaman.Equals(idPinjaman));

            if (data == null)
            {
                return 0;
            }

            if(data.SisaAngsuran == 0)
            {
                return 2;
            }

            else
            {
                if (data.SisaAngsuran - 1 == 0)
                {
                    data.Status = "Lunas";
                }

                Angsuran angsuran = new Angsuran()
                {
                    IdPinjaman = data.IdPinjaman,
                    AngsuranKe = data.LamaAngsuran - data.SisaAngsuran + 1,
                    BesarAngsuran = data.BesarAngsuran,
                    Denda = HitungDenda(data.TglTempo),
                    SisaPinjaman = data.SisaPinjaman - data.BesarAngsuran,
                    UserEntry = userEntry,
                    TglEntry = DateTime.Now
                };

                _context.Angsuran.Add(angsuran);
                var result = _context.SaveChanges();

                //Pinjaman pinjaman = new Pinjaman()
                //{
                //    IdPinjaman = data.IdPinjaman,
                //    IdJenisPinjaman = data.IdJenisPinjaman,
                //    BesarPinjaman = data.BesarPinjaman,
                //    BesarAngsuran = data.BesarAngsuran,
                //    LamaAngsuran = data.LamaAngsuran,
                //    SisaAngsuran = data.SisaAngsuran - 1,
                //    SisaPinjaman = data.SisaPinjaman - data.BesarAngsuran,
                //    UserEntry = userEntry,
                //    TglEntry = data.TglEntry,
                //    TglTempo = data.TglTempo.AddMonths(1),
                //    status = data.status
                //};

                data.SisaAngsuran = data.SisaAngsuran - 1;
                data.SisaPinjaman = data.SisaPinjaman - data.BesarAngsuran;
                data.TglTempo = data.TglTempo.AddMonths(1);

                _context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                result = _context.SaveChanges();
                return result;
            }
        }

        public AngsuranUser GetDataAngsuranPinjaman(int idPinjaman)
        {
            var data = _context.Pinjaman.Include(x => x.User).SingleOrDefault(x => x.IdPinjaman.Equals(idPinjaman));
            if (data == null)
            {
                return null;
            }

            AngsuranUser angsuranUser = new AngsuranUser()
            {
                NomorAnggota = data.User.NomorAnggota,
                IdPinjam = data.IdPinjaman,
                BesarPinjam = data.BesarPinjaman,
                Angsuran = data.BesarAngsuran,
                NamaAnggota = data.User.Nama,
                TglPinjam = data.TglEntry,
                LamaAngsur = data.LamaAngsuran,
                AngsuranKe = data.LamaAngsuran - data.SisaAngsuran + 1
            };

            return angsuranUser;
        }

        public IEnumerable<Angsuran> RiwayatAngsuran(int idPinjaman)
        {
            return _context.Angsuran.Where(x => x.IdPinjaman == idPinjaman).ToList();
        }
    }
}
