using RestWithAspNet5Example.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet5Example.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("Author")]
        public string Author { get; set; }
        [Column("Launch_Date")]
        public DateTime Launch_Date { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        [Column("Title")]
        public string Title { get; set; }

    }
}
