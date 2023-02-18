using RestWithAspNet5Example.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet5Example.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("Gender")]
        public string Gender { get; set; }
        [Column("enabled")]
        public bool Enabled { get; set; }
    }
}
