using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
         private readonly DataContext _context;

         public ProductController(DataContext context)
         {
            _context = context;
         }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct (Product product)
        {
          Product p1 = new Product   {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            UpdatedAt = DateTime.Now,
        };
        _context.Products.Add(p1);
        await _context.SaveChangesAsync();
        return p1;
        }

         [HttpGet]
         public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct ()  {
            return await _context.Products.ToListAsync();
        }


         [HttpGet( "{id}")]
         public async Task<ActionResult<Product>> GetProduct (int id)  {
            var p = await _context.Products.FindAsync(id);

            if(p==null) {
                return NotFound();
            }
            return Ok();
       } 

         [HttpDelete]
         public async Task<ActionResult<Product>> DeleteProduct( int id) {
                var p = await _context.Products.FindAsync(id);
              
                if(p == null) {
                return NotFound();
            } 
             _context.Products.Remove(p);
             await _context.SaveChangesAsync();
             return Ok();
            } 


         [HttpPut]
         public async Task<IActionResult> PutProduct(int id, Product product) {
           
           if(id != product.Id) {
                return BadRequest();
            } 
            var p = await _context.Products.FindAsync(id);
           
            if(p == null) {
                return NotFound();
            } 

            p.Name = product.Name;
            p.Description = product.Description;
            p.Price = product.Price;
            p.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok();
         } 
    }
}