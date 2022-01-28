using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class producersController : Controller
    {
        private readonly AppDbContext _context;
        public producersController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data =  await _context.producers.ToListAsync();
            return View(data);
        }
    }
}
