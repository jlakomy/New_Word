using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N_WORD.Entities;
using N_WORD.Models;
using N_WORD.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD.Models
{
    public class CreateWordDto
    {
        [Required]
        [MaxLength(20)]
        public string PlMeaning { get; set; }
        [Required]
        [MaxLength(20)]
        public string EnMeaning { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
