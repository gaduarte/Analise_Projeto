using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace biblioteca_trabalho.Models
{
    [Table("GeneralBook")]
    public class GeneralBook: Books
    {
        public string? Descricao {get; set;}
        public string? Edicao {get; set;}
        
    }
}