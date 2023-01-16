using Legoas_Test.Data;
using Legoas_Test.Models;
using Legoas_Test.Models.ManyToMany;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

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
        public async Task<ActionResult<RegisterModel>> Register()
        {
            var result = new RegisterModel();
            result.Peran = await _dataContext.Peran.ToListAsync();
            result.Layar = await _dataContext.Layar.ToListAsync();
            result.Kantor = await _dataContext.Kantor.ToListAsync();
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {

                using (var context = _dataContext)
                {
                    await context.Pengguna.AddAsync(registerModel.Pengguna);
                    await context.SaveChangesAsync();

                    registerModel.Akun.id_pengguna = registerModel.Pengguna.id;
                    await context.Akun.AddAsync(registerModel.Akun);
                    await context.SaveChangesAsync();

                    var akunId = registerModel.Akun.id;

                    Akun_Peran akun_Perans = new Akun_Peran();
                    List<Peran> peranChoosen = registerModel.Peran.Where(peran => peran.isTrue == true).ToList();

                    for (var i = 0; i < peranChoosen.Count; i++)
                    {
                        var peran = peranChoosen[i];
                        akun_Perans.akun_id = registerModel.Akun.id;
                        akun_Perans.peran_id = peran.id;
                        await context.Akun_Peran.AddAsync(akun_Perans);
                    }
                        await context.SaveChangesAsync();

                  Akun_Layar akun_Layar = new Akun_Layar();
                    List<Layar> layarChoosen = registerModel.Layar.Where(layar => layar.isTrue == true).ToList();

                    foreach (var layar in layarChoosen)
                    {
                        akun_Layar.akun_id = registerModel.Akun.id;
                        akun_Layar.layar_id = layar.id;
                        await context.Akun_Layar.AddAsync(akun_Layar);
                        await context.SaveChangesAsync();
                    }

                    Pengguna_Kantor pengguna_Kantor = new Pengguna_Kantor();
                    List<Kantor> kantorChoosen = registerModel.Kantor.Where(kantor => kantor.isTrue == true).ToList();

                    foreach (var kantor in kantorChoosen)
                    {
                        pengguna_Kantor.pengguna_id = registerModel.Pengguna.id;
                        pengguna_Kantor.kantor_id = kantor.id;
                        await context.Pengguna_Kantor.AddAsync(pengguna_Kantor);
                        await context.SaveChangesAsync();
                    }

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
