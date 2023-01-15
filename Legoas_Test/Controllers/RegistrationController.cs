using Legoas_Test.Data;
using Legoas_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Legoas_Test.Controllers
{
    public class RegistrationController : Controller
    {
        readonly DataContext _dataContext;
        public RegistrationController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Peran>>> Peran()
        {
            var result = await _dataContext.Peran.ToListAsync();
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Register(AkunModel akunModel)
        {
            using (var context = _dataContext)
            {
                await context.Akun.AddAsync(akunModel);
                await context.SaveChangesAsync();
            }

            return Ok("Akun Created!");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
