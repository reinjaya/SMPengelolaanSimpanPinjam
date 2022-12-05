using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Repositories.Data
{
    public class JenisPinjamanRepository : GeneralRepository<JenisPinjaman>
    {
        private MyContext _context;
        public JenisPinjamanRepository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
