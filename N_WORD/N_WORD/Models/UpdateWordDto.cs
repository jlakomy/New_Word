using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N_WORD.Models
{
    public class UpdateWordDto
    {
        [MaxLength(20)]
        public string PlMeaning { get; set; }
        [MaxLength(20)]
        public string EnMeaning { get; set; }
        public string Description { get; set; }
        public string ExampleSentence { get; set; }
    }
}
