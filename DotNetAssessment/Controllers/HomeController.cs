using DotNetAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DotNetAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataDbContext _dbContext;


        public HomeController(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult RegisterData(login logins)
        {

            if (logins != null)
            {

                var data = _dbContext.login.FirstOrDefault(x => x.id == logins.id);
                if (data == null)
                {
                    _dbContext.login.Add(logins);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Login");
                }
                return Ok();

            }
            return Ok();

        }
        public IActionResult LoginData(login logins)
        {
            var data = _dbContext.login.FirstOrDefaultAsync(x => x.Email == logins.Email && x.password == logins.password);
            if (data != null)
            {
                return RedirectToAction("Index","Product");

            }
            return RedirectToAction("Login");

        }
         

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
