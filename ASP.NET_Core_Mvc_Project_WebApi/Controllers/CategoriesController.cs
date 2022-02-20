using ASP.NET_Core_Mvc_Project_WebApi.Models;
using ASP.NET_Core_Mvc_Project_WebApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Mvc_Project_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public CategoriesController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
            var list = new List<CategoryModel>();
            foreach (var category in await _context.Categories.ToListAsync())
                list.Add(new CategoryModel(category.Id, category.Name));

            return list;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryEntity(int id)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);

            if (categoryEntity == null)
            {
                return NotFound();
            }

            return new CategoryModel(categoryEntity.Id, categoryEntity.Name);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryEntity( CategoryEntity categoryEntity)
        {
            if (categoryEntity.Name.Contains(" "))
            {
                return BadRequest("Namnet får ej innehålla blanksteg");
            }
            else
            {
                if (categoryEntity.Id != categoryEntity.Id)
                {
                    return BadRequest();
                }

                _context.Entry(categoryEntity).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryEntityExists(categoryEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
           
        }



        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryEntity>> PostCategoryEntity(CreateCategoryModel model)
        {


            if (model.Name.Contains(" "))
            {
                return BadRequest("Namnet får ej innehålla blanksteg");
            }
            else
            {
                var _category = await _context.Categories.FirstOrDefaultAsync(x => x.Name == model.Name);
                if (_category != null)
                    return new ConflictObjectResult(new CategoryModel(_category.Id, _category.Name));

                var categoryEntity = new CategoryEntity { Name = model.Name };
                _context.Categories.Add(categoryEntity);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCategoryEntity", new { id = categoryEntity.Id }, new CategoryModel(categoryEntity.Id, categoryEntity.Name));
            }
            
        }


        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryEntity(int id)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categoryEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryEntityExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
