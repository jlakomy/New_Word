using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace N_WORD.Entities
{
    public class Word
    {
        public int Id { get; set; }
        public string PlMeaning { get; set; }
        public string EnMeaning { get; set; }
        public string Description { get; set; }
        public string ExampleSentence { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
