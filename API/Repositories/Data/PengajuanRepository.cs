using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Repositories.Data
{
    public class PengajuanRepository : GeneralRepository<Pengajuan>
    {
        private readonly MyContext _context;
        public PengajuanRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public double BesarAngsuran(double besarPinjaman, int jenisPinjaman)
        {
            var data = _context.JenisPinjaman.Find(jenisPinjaman);
            var angsuran = Math.Round((besarPinjaman * Math.Pow((1 + data.Bunga), data.LamaAngsuran)) / data.LamaAngsuran);
            return angsuran;
        }

        public bool CekKelayakan(int id)
        {
            int belumLunas = _context.Pinjaman.Where(x => x.Status == "Belum Lunas" && x.IdUser == id).Count();
            int menunggu = _context.Pengajuan.Where(x => x.Status == "Menunggu" && x.IdUser == id).Count();

            if(belumLunas < 2 || menunggu == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public JenisPinjaman GetJenisPinjaman(int id)
        {
            return _context.JenisPinjaman.Find(id);
        }

        public IEnumerable<Pengajuan> GetDaftarPengajuanAnggota(int id)
        {
           return _context.Pengajuan.Where(x => x.IdUser == id).ToList();
        }

        public IEnumerable<Pengajuan> GetDaftarPengajuan()
        {
            return _context.Pengajuan.ToList();
        }

        public int TambahPengajuanBaru(Pengajuan pengajuan)
        {
            if(CekKelayakan(pengajuan.IdUser))
            {
                pengajuan.Status = "Menunggu";
                pengajuan.BesarAngsuran = BesarAngsuran(pengajuan.BesarPinjaman, pengajuan.IdJenisPinjaman);
                _context.Pengajuan.Add(pengajuan);
                var result = _context.SaveChanges();
                return result;
            }
            return 2;
        }

        public int ProsesPengajuan(int idPengajuan, bool terimaPengajuan)
        {
            var pengajuan = _context.Pengajuan.Include(x => x.JenisPinjaman).SingleOrDefault(x => x.IdPengajuan.Equals(idPengajuan));
            if(pengajuan == null)
            {
                return 0;
            }

            if(terimaPengajuan)
            {
                pengajuan.Status = "Diterima";
                pengajuan.TglAcc = DateTime.Now;
                _context.Entry(pengajuan).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                Pinjaman pinjaman = new Pinjaman()
                {
                    IdUser = pengajuan.IdUser,
                    IdJenisPinjaman = pengajuan.IdJenisPinjaman,
                    BesarPinjaman = pengajuan.BesarPinjaman,
                    BesarAngsuran = pengajuan.BesarAngsuran,
                    LamaAngsuran = pengajuan.JenisPinjaman.LamaAngsuran,
                    SisaAngsuran = pengajuan.JenisPinjaman.LamaAngsuran,
                    SisaPinjaman = pengajuan.BesarPinjaman,
                    UserEntry = "Admin", //Testing, nanti diubah
                    TglEntry = DateTime.Now,
                    TglTempo = DateTime.Now.AddMonths(1),
                    Status = "Belum Lunas"
                };

                _context.Pinjaman.Add(pinjaman);
                var result = _context.SaveChanges();
                return result;
            }
            else 
            {
                pengajuan.Status = "Ditolak";
                _context.Entry(pengajuan).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var result = _context.SaveChanges();
                return result;
            }

        }
    }
}
