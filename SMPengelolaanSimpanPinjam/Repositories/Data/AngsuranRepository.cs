using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Repositories.Data
{
    public class AngsuranRepository : GeneralRepository<Angsuran>
    {
        private MyContext _context;
        public AngsuranRepository(MyContext context) : base(context)
        {
            _context = context;
        }


    }
}
