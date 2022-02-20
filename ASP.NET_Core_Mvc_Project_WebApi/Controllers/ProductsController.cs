using ASP.NET_Core_Mvc_Project_WebApi.Models;
using ASP.NET_Core_Mvc_Project_WebApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ASP.NET_Core_Mvc_Project_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ProductsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
        {
            var list = new List<ProductModel>();
            foreach (var product in await _context.Products.Include(x => x.Category).ToListAsync())
                list.Add(new ProductModel(product.Id, product.Name, product.Description, product.Price, product.Category.Id, product.Category.Name));

            return list;
        }


        [HttpGet("CategoryName")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductsByCategoryId(string category)
        {

            var list = new List<ProductModel>();
            foreach (var product in await _context.Products.Where(x => x.Category.Name.ToLower() == category.ToLower()).ToListAsync())
            {
                list.Add(new ProductModel(product.Id, product.Name, product.Description, product.Price, product.CategoryId,""));
            }
            return list;
        }


        //GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductEntity(int id)
        {
            var productEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (productEntity == null)
                return NotFound();

            return new ProductModel(productEntity.Id, productEntity.Name, productEntity.Description, productEntity.Price, productEntity.Category.Id, productEntity.Category.Name);
            
        }


        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductEntity(int id, UpdateProductModel model)
        {
            if (id != model.Id)
                return BadRequest();

            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
                return NotFound();

            productEntity.Name = model.Name;
            productEntity.Description = model.Description;
            productEntity.Price = model.Price;
            productEntity.CategoryId = model.CategoryId;

            _context.Entry(productEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductEntity>> PostProductEntity(CreateProductModel model)
        {
            var productEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Name == model.Name);
            if (productEntity != null)
                return new ConflictObjectResult(new ProductModel(productEntity.Id, productEntity.Name, productEntity.Description, productEntity.Price, productEntity.CategoryId, ""));

            var category = await _context.Categories.FindAsync(model.CategoryId);
            if (category == null)
                return new BadRequestObjectResult(new ErrorMessageModel { StatusCode = 400, Error = "Invalid or no category id provided." });

            productEntity = new ProductEntity(model.Name, model.Description, model.Price, category.Id);
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductEntity", new { id = productEntity.Id }, new ProductModel(productEntity.Id, productEntity.Name, productEntity.Description, productEntity.Price, productEntity.CategoryId, ""));
        }



        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
                return NotFound();

            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
