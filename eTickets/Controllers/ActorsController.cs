using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        public readonly IActorsService _IActorsService;
        public ActorsController(IActorsService IActorsService)
        {
            _IActorsService = IActorsService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _IActorsService.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL", "FullName", "Bio")] Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
           await _IActorsService.AddAsync(actor);
            return View();
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _IActorsService.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _IActorsService.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureURL", "FullName", "Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
             await _IActorsService.UpdateAsync(id , actor);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _IActorsService.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var actorDetails = await _IActorsService.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            await _IActorsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
