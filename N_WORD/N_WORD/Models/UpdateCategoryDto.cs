using N_WORD.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD.Models
{
    public class UpdateCategoryDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
