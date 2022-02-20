using ASP.NET_Core_Mvc_Project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Mvc_Project.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoriesViewModel> categories = new List<CategoriesViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7197/api/");
                categories = await client.GetFromJsonAsync<IEnumerable<CategoriesViewModel>>("categories");
                
            }
            return View(categories);
        }

        [HttpGet("/Categories/{selectedCategory}")]
        public async Task<IActionResult> CategoryProducts(string selectedCategory)
        {
            IEnumerable<ProductsViewModel> products = new List<ProductsViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7197/api/");
                products = await client.GetFromJsonAsync<IEnumerable<ProductsViewModel>>("products/CategoryName?category=" + selectedCategory);

            }
            return View(products);
        }

        [HttpGet("/Products/{selectedProduct}")]
        public async Task<IActionResult> ProductFromId(int selectedProduct)
        {
            ProductsViewModel product = new ProductsViewModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7197/api/");
                product = await client.GetFromJsonAsync<ProductsViewModel>("products/" +selectedProduct);
            }
            return View(product);
        }
    }
}
