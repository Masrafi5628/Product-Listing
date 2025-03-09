
using Microsoft.AspNetCore.Mvc;
using Product_Listing.Models;

namespace Product_Listing.Controllers
{
    public class ProductController : Controller
    {
        
        private static List<Product> products = new List<Product>();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = products.Count + 1; 
                products.Add(product);
                return RedirectToAction("ProductList");
            }
            return View("Index");
        }

     
        public ActionResult ProductList()
        {
            return View(products);
        }




        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View("EditForm",product);
        }

        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
            }
            return RedirectToAction("ProductList");
        }

        public ActionResult Delete(int id)
        {
            Product product = products.Find(p => p.Id == id);
            products.Remove(product);
            return RedirectToAction("ProductList");
        }
    }
}
