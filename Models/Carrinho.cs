using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Venda_Produto.Models
{
    public class Carrinho
    {
        public int Id {get; set;}
         public int? UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}