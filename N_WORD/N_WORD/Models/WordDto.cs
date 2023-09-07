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
    public class WordDto
    {
        public int Id { get; set; }
        public string PlMeaning { get; set; }
        public string EnMeaning { get; set; }
        public string Description { get; set; }
        public string ExampleSentence { get; set; }
        public string CategoryName { get; set; }

    }
}
