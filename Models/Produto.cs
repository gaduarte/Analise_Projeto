using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venda_Produto.Models
{
    public class Produto
    {
        public int Id {get; set;}
        [Display(Name = "Descrição")]
        public string? Descricao {get; set;}
        [Display(Name = "Imagem")]
        public string? PathImagem {get; set;}
        [Display(Name = "Preço")]
        public decimal Preco {get; set;}
        public int Quantidade {get; set;}
        public int CategoriaId {get; set;}
        public Categoria? Categoria {get; set;}
    }
}