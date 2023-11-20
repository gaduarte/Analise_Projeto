
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biblioteca_trabalho.Models
{
    public class Books
    {
        [Key]
        public int? Id {get; set;}

        [Display(Name = "Nome do Autor")]
        public string? AuthorName {get; set;}

        [Display(Name = "Nome do Livro")]
        public string? BookName {get; set;}

        [Display(Name = "Estoque")]
        public int NoofBooks {get; set;}

        [Display(Name = "Catálogo")]
        public int? CatalogId {get; set;}
        public Catalog? Catalog {get; set;}

        [ForeignKey("MemberId")]
        public int? MemberId {get; set;}
        public virtual Member? Member {get; set;}

        public virtual Librarian? Librarian1 {get; set;}
        public virtual Librarian? Librarian2 {get; set;}

        public void RemoveFirmCatalog(){
            Catalog = null;
        }
        public void AddCatalog(Catalog catalog){
            Catalog = catalog;
        }
    }
}