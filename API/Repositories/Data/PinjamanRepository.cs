using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;
using WebAPI.ViewModel;

namespace WebAPI.Repositories.Data
{
    public class PinjamanRepository : GeneralRepository<Pinjaman>
    {
        private MyContext _context;
        public PinjamanRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<PinjamanAnggotaVM> DaftarPinjamanAnggota(int idUser)
        {
            var data = _context.Pinjaman.Include(x => x.JenisPinjaman).Where(x => x.IdUser == idUser).ToList();

            List<PinjamanAnggotaVM> result = new List<PinjamanAnggotaVM>();

            foreach (var item in data)
            {
                result.Add(new PinjamanAnggotaVM
                {
                    IdPinjaman = item.IdPinjaman,
                    TglEntry = item.TglEntry,
                    JenisPinjaman = item.JenisPinjaman.NamaPinjaman,
                    BesarAngsuran = item.BesarAngsuran,
                    BesarPinjaman = item.BesarPinjaman,
                    LamaAngsuran = item.LamaAngsuran,
                    SisaAngsuran = item.SisaAngsuran,
                    TglTempo = item.TglTempo,
                    Status = item.Status,
                    SisaPinjaman = item.SisaPinjaman,
                });
            }

            return result;
        }
        
    }
}
