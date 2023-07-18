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
    [Route("api/category/{categoryId}/word")]
    [ApiController]
    [Authorize]
    public class WordController : ControllerBase
    {
        private readonly    IWordService _WordService;

        public WordController(IWordService wordService)
        {
            _WordService = wordService;
        }

        [HttpDelete("{wordId}")]
        [Authorize(Roles = "Admin,Menager")]
        public ActionResult Delete([FromRoute] int categoryId, [FromRoute] int wordId)
        {
            _WordService.Delete(categoryId, wordId);

            return NoContent();
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int categoryId, [FromBody] CreateWordDto dto)
        {
            var wordId = _WordService.Create(categoryId, dto);

            return Created($"/api/category/{categoryId}/word/{wordId}", null);
        }
        [HttpGet("{wordId}")]
        [Authorize(Roles = "Admin,Menager")]
        public ActionResult<WordDto> GetById([FromRoute] int categoryId, [FromRoute] int wordId)
        {
            var word = _WordService.GetById(categoryId, wordId);

            return Ok(word);
        }
        [HttpGet]
        public ActionResult<List<WordDto>> GetAll([FromRoute] int categoryId)
        {
            var words = _WordService.GetAll(categoryId);

            return Ok(words);
        }
    }
}
