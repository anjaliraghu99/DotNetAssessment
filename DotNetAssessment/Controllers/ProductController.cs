using DotNetAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DotNetAssessment.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataDbContext Context;
        public ProductController(DataDbContext context)
        {
            Context = context;
        }
        [HttpGet]

        public List<Product> Getdata()
        {
            var data = Context.Product.ToList();
            return data;
        }
        [HttpPost]
        public IActionResult AddProducts(Product product)
        {

            Context.Product.Add(product);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Update(string Id) {
            var data = Context.Product.FirstOrDefault(x => x.Id == Id);

            return View(data);
        }
        public IActionResult Updatedetails(string Id,Product product)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var data = Context.Product.FirstOrDefault(x => x.Id == Id);
            if(data != null)
            {
                data.Price = product.Price;
                data.ProductName = product.ProductName;
                data.ProductDescription = product.ProductDescription;
            }
            Context.SaveChanges();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var regis = await Context.Product.FindAsync(Id);
            if (regis != null)
            {
                Context.Product.Remove(regis);
                await Context.SaveChangesAsync();
               
            }
            return RedirectToAction("Index");
        }

      
        public IActionResult Index()
        {

            var data = Getdata();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();

        }
        //public IActionResult Update()
        //{
        //    return View();

        //}
    }
}

