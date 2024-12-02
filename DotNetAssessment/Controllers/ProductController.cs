using DotNetAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

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
        public IActionResult Index()
        {

            var data = Context.Product.ToList(); 
            return View(data);
        }
        
        public IActionResult ManageData(string DataAction,string id)
        {
            ViewBag.DataAction = DataAction;
            if(DataAction == "Edit")
            {
                var data = Context.Product.FirstOrDefault(x => x.Id == id);
                if (data != null)
                {
                    return View(data);
                }
            }
            return View();

        }
        [HttpPost]
        public IActionResult ManageProduct(string DataAction, int id, Product product)
        {
            if (DataAction == "Create")
            {
                if (product.Id != null)
                {
                    var data = Context.Product.FirstOrDefault(x => x.Id == product.Id);
                    if (data == null)
                    {
                        Context.Product.Add(product);
                        Context.SaveChanges();
                        TempData["SuccessMessage"] = "Data created successfully!";
                        return RedirectToAction("Index");
                        

                    }

                }
            }
            if (DataAction == "Edit")
            {
                if (product.Id != null)
                {
                    var data = Context.Product.FirstOrDefault(x => x.Id == product.Id);
                    if (data != null)
                    {
                        Context.Entry(data).CurrentValues.SetValues(product);

                        Context.SaveChanges();
                        TempData["SuccessMessage"] = "Data Updated successfully!";
                        return RedirectToAction("Index");
                    }
                }

            }

            if (DataAction == "Delete")
            {
               
                    var data = Context.Product.FirstOrDefault(x => x.Id == product.Id);
                    if (data != null)
                    {
                        Context.Product.Remove(data);
                        Context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
         
            return Ok();

        }

       
    }
}

