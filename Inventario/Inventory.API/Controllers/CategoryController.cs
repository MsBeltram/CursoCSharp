
using Inventory.Entities;
using Inventory.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Inventary.DTOs.Category;
using AutoMapper;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController (ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryToCreateDto categoryToCreateDto)
        {
            var category = new Category {
                    Name = categoryToCreateDto.Name,
                    Description = categoryToCreateDto.Description,
                    CreatedAt = DateTime.Now
                 };
            var categoryCreated = await _categoryRepository.AddAsync(category);

            var categoryCreatedTdos = new CategoryToListDto {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    CreatedAt = category.CreatedAt,
                    UpdatedAt = category.UpdatedAt
                 };
            return Ok(categoryCreated);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryToEditDto categoryToEditDto)
        {
            if(id != categoryToEditDto.Id)
            {
                return BadRequest();
            }
            var categoryToUpdate = await _categoryRepository.GetByIdAsync(id);
            if(categoryToUpdate ==null){
                return BadRequest();
            }
            categoryToUpdate.Name = categoryToEditDto.Name;
            categoryToUpdate.Description = categoryToEditDto.Description;
            categoryToUpdate.UpdatedAt = DateTime.Now;
            var update = await _categoryRepository.UpdateAsync(id,categoryToUpdate);
            if(!update){
                return NoContent();
            }
            var category = await _categoryRepository.GetByIdAsync(id);
            return Ok(category);
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
             var c = await _categoryRepository.GetByIdAsync(id);
            if(c ==null){
                return NotFound();
            }

            var deleted = await _categoryRepository.DeletAsync(c);

            if(!deleted){
                return Ok("Registro no borrado consultar el log");
            }
            return Ok("Registro borrado");
        }

         [HttpGet( "{id}")]
         public async Task<ActionResult<Product>> GetCategory (int id)  {
            var p = await _categoryRepository.GetByIdAsync(id);

            if(p==null) {
                return NotFound();
            }
            return Ok(p);
       } 

    }
}