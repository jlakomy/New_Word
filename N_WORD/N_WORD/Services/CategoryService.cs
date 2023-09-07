using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using N_WORD.Entities;
using N_WORD.Exceptions;
using N_WORD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD.Services
{
    public interface ICategoryService
    {
        CategoryDto GetById(int id);
        IEnumerable<CategoryDto> GetAll();
        int Create(CreateCategoryDto newCategory);
        void Delete(int id);
        void Update(UpdateCategoryDto dto, int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly N_WordDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(N_WordDbContext dbContext, IMapper mapper, ILogger<CategoryService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public CategoryDto GetById(int id)
        {
            var category = _dbContext
                .Categories
                .Include(c => c.Words)
                .FirstOrDefault(w => w.Id == id);
            if (category is null) throw new NotFoundException("Category not found");
            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }
        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _dbContext
                .Categories
                .Include(c => c.Words)
                .ToList();

            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesDtos;
        }
        public int Create (CreateCategoryDto newCategory)
        {
            var category = _mapper.Map<Category>(newCategory);
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return category.Id;
        }
        public void Delete(int id)
        {
            _logger.LogError($"Category with ID: {id} DELETE action invoked");
            var category = _dbContext
                .Categories
                .FirstOrDefault(w => w.Id == id);

            if (category is null) throw new NotFoundException("Category not found");

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
        public void Update(UpdateCategoryDto dto, int id)
        {
            var category = _dbContext
                .Categories
                .FirstOrDefault(w => w.Id == id);

            if (category is null) throw new NotFoundException("Category not found");
            if(dto.Name != null) category.Name= dto.Name;
            if(dto.Description != null )category.Description= dto.Description;

            _dbContext.SaveChanges();
        }
    }
}
