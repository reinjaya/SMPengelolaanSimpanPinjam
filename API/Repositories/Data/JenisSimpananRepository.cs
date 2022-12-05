using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Repositories.Data
{
    public class JenisSimpananRepository : GeneralRepository<JenisSimpanan>
    {
        private MyContext _context;
        public JenisSimpananRepository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
