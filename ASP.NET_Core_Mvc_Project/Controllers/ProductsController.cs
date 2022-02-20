using ASP.NET_Core_Mvc_Project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Mvc_Project.Controllers
{
    public class ProductsController : Controller
    {
        [Authorize]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductsViewModel> products = new List<ProductsViewModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7197/api/");
                products = await client.GetFromJsonAsync<IEnumerable<ProductsViewModel>>("products");
                
            }

            return View(products);
        }
    }
}
