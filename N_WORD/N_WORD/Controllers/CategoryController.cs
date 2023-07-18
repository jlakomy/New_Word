using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N_WORD.Entities;
using N_WORD.Models;
using N_WORD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD.Controllers
{
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoryController :ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Menager")]
        public ActionResult Update([FromBody] UpdateCategoryDto dto, [FromRoute] int id)
        {
            _categoryService.Update(dto, id);

            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Menager")]
        public ActionResult Delete([FromRoute] int id)
        {
            _categoryService.Delete(id);
            
            return NoContent();
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Menager")]
        public ActionResult Create([FromBody] CreateCategoryDto dto)
        {
            var id = _categoryService.Create(dto);

            return Created($"/api/category/{id}", null);
        }
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = _categoryService.GetAll();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetById([FromRoute] int id)
        {
            
            var category = _categoryService.GetById(id);
            
            return Ok(category);

        }
    }
}
