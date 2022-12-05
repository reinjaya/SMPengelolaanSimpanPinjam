using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Repositories.Data
{
    public class PinjamanRepository : GeneralRepository<Pinjaman>
    {
        private MyContext _context;
        public PinjamanRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Pinjaman> DaftarPinjamanAnggota(int idUser)
        {
            return _context.Pinjaman.Where(x => x.IdUser == idUser).ToList();
        }
        
    }
}
