using Curso.NetAngular.Data;
using Curso.NetAngular.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curso.NetAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // using "api/" is optional but it's conventional to do it
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int? id)
        {
            if(id is null)
                return BadRequest();

            Product product = await _context.Products.FindAsync(id);
            
            if (product is null)
                return NotFound();
            else
                return Ok(product);
        }
    }
}
