using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Repositories.Data
{
    public class TabunganRepository : GeneralRepository<Tabungan>
    {
        private MyContext _context;
        public TabunganRepository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
