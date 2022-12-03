using Microsoft.SqlServer.Server;
using WebAPI.Context;
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

        //Menambahkan simpanan pokok setelah menambahkan anggota
        public int AddSimpanan(int idUser, string userEntry, DateTime tglMulai, DateTime tglEntry)
        {
            Simpanan simpanan = new Simpanan()
            {
                IdSimpanan = 0,
                BesarSimpanan = 10000, //Simpanan Pokok
                IdJenisSimpanan = 1,
                IdUser = idUser,
                UserEntry = userEntry,
                TglMulai = tglMulai,
                TglEntry = tglEntry
            };

            _context.Simpanan.Add(simpanan);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
