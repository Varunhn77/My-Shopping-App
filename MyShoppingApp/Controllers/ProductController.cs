using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using MyShoppingApp.Models;

namespace MyShoppingApp.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> productList = new List<Product>();

        public IActionResult Index()
        {
            //List<int> products = new List<int>();

            //Product productObj = new Product();
            //productObj.Id = 1;
            //productObj.Name = "Test1";
            //productObj.Description = "Test1";
            //productObj.Category = "Sports";
            //productList.Add(productObj);

            //productObj = new Product();
            //productObj.Id = 2;
            //productObj.Name = "Test2";
            //productObj.Description = "Test2";
            //productObj.Category = "Fashion";
            //productList.Add(productObj);
            return View(productList);
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            //How to pass data from action to view page
            ViewBag.message = "Succesfully added....!";
            if (productList.Count == 0)
                product.Id = 1;
            else
                product.Id = productList[productList.Count - 1].Id+1;

            productList.Add(product);
            return View("Index" , productList);
        }
        public IActionResult EditProduct(int id)
        {
            var result = productList.Where(obj=> obj.Id == id).ToList();
            return View(result[0]);
        }

    }
}
