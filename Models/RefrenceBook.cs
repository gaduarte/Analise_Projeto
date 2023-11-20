using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace biblioteca_trabalho.Models
{
    [Table("RefrenceBook")]
    public class RefrenceBook: Books
    {
        public string? Avaliacoes {get; set;}
        public string? Citacoes {get; set;}
        public int? Preco {get; set;}
        public void SearchRefb(){}
    }
}