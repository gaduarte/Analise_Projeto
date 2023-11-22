using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venda_Produto.Models
{
    public class Usuario
    {
        public int Id {get; set;}
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string? Login {get; set;}
        [Display(Name = "Senha")]
        public string? Password {get; set;}
        [Display(Name = "Email")]
        public string? Email {get; set;}

       public virtual ICollection<Carrinho> Carrinho { get; set; } = new List<Carrinho>();

    }
}