using DotNetAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.Internal.TypeHandlers.FullTextSearchHandlers;
using System;
using System.ComponentModel.DataAnnotations;
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
        
        public IActionResult ManageData(string DataAction,int id)
        {
            ViewBag.DataAction = DataAction;
            if(DataAction == "Edit")
            {
                var data =  Context.Product.FirstOrDefault(x => x.Id == id);
                if (data != null)
                {
                    return View(data);
                }
            }
            return View();

        }
        public async Task<Tuple<string, bool>> ValidateData(Product product)
        {
            if (string.IsNullOrEmpty(product.ProductName))
            {
                var message = "Name should not be null or empty";
                return Tuple.Create(message, false);

            }
            if (string.IsNullOrEmpty(product.Price.ToString()))
            {
                var message = "Price should not be null or empty";
                return Tuple.Create(message, false);

            }
            if (string.IsNullOrEmpty(product.ProductCategory))
            {
                var message = "ProductCategory should not be null or empty";
                return Tuple.Create(message, false);

            }
            return Tuple.Create("Product is valid", true);
         }

        



        [HttpPost]
        public async Task<IActionResult> ManageProduct(string DataAction, Product product)
        {

            if (DataAction == "Create")
            {

                if (product != null)
                {
                    var (message, isValid) =  await ValidateData(product);
                    if (isValid == false) {
                        ViewBag.message = message;
                        ViewBag.DataAction = DataAction;  

                        return View("ManageData", product);
                    }

                    var data = Context.Product.FirstOrDefault(x => x.Id == product.Id);
                    if (data == null)
                    {
                        Context.Product.Add(product);
                        await Context.SaveChangesAsync();
                        TempData["SuccessMessage"] = "Data created successfully!";
                        return RedirectToAction("Index");
                    }

                }
            }
            if (DataAction == "Edit")
            {
                if (product!=null)
                {
                    var data = Context.Product.FirstOrDefault(x => x.Id == product.Id);
                    if (data != null)
                    {
                        Context.Entry(data).CurrentValues.SetValues(product);

                        await Context.SaveChangesAsync();
                        TempData["SuccessMessage"] = "Data Updated successfully!";
                        return RedirectToAction("Index");
                    }
                }

            }

            if (DataAction == "Delete")
            {
                if(product != null)
                {
                    var data = Context.Product.FirstOrDefault(x => x.Id == product.Id);
                    if (data != null)
                    {
                        Context.Product.Remove(data);
                        await Context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                }

            }

            return BadRequest("Invalid Input! Something Went Wrong.");

        }


        [HttpGet]
        public ActionResult GetCategoryData(string categoryName)
        {
            switch (categoryName)
            {
                case "Category":
                    var categorydata = Context.Quentity
                                .Select(x => new
                                {
                                    x.Id,
                                    x.value
                                }).Distinct().ToList();
                    return Json(categorydata);

                case "Value":
                    var Quentitydata  = Context.Category
                                .Select(x => new
                                {
                                    x.Id,
                                    x.CategoryName
                                }).Distinct().ToList();
                   return Json(Quentitydata);
                   

            }
            return BadRequest("Invalid Input! Something Went Wrong.");
        }


    
        
       


    }
}

