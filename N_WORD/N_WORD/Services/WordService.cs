using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_WORD.Entities;
using N_WORD.Exceptions;
using N_WORD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD.Services
{
    public interface IWordService
    {
        int Create(int categoryId, CreateWordDto dto);
        public WordDto GetById(int categoryId, int wordId);
        List<WordDto> GetAll(int categoryId);
        public void Delete(int categoryId, int wordId);
    }
    public class WordService : IWordService
    {
        private readonly N_WordDbContext _dbContext;
        private readonly IMapper _mapper;

        public WordService(N_WordDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(int categoryId, CreateWordDto dto)
        {
            var category = _dbContext
                .Categories
                .FirstOrDefault(c => c.Id == categoryId);

            if (category is null) throw new NotFoundException("Category not found");

            var newWord = _mapper.Map<Word>(dto);
            newWord.CategoryId = categoryId;

            _dbContext.Words.Add(newWord);
            _dbContext.SaveChanges();

            return newWord.Id;
        }
        public WordDto GetById(int categoryId, int wordId)
        {
            var category = _dbContext
                .Categories
                .FirstOrDefault(w => w.Id == categoryId);

            if (category is null) throw new NotFoundException("Category not found");

            var word = _dbContext
                .Words
                .FirstOrDefault(w => w.Id == wordId);
            if (word is null || word.CategoryId != categoryId) throw new NotFoundException("Word not found");

            var wordDto = _mapper.Map<WordDto>(word);
            return wordDto;

        }
        public List<WordDto> GetAll(int categoryId)
        {
            var category = _dbContext
                .Categories
                .Include(c => c.Words)
                .FirstOrDefault(w => w.Id == categoryId);

            if (category is null) throw new NotFoundException("Category not found");

            var worsDtos = _mapper.Map<List<WordDto>>(category.Words);
            return worsDtos;
        }
        public void Delete(int categoryId, int wordId)
        {
            var category = _dbContext.Categories
                .FirstOrDefault(w => w.Id == categoryId);

            if (category is null) throw new NotFoundException("Category not found");

            var word = _dbContext
                .Words
                .FirstOrDefault(w => w.Id == wordId);
            if (word is null || word.CategoryId != categoryId) throw new NotFoundException("Word not found");
            _dbContext.Words.Remove(word);
            _dbContext.SaveChanges();
        }
    }
}
