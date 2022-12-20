using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet5Example.Model.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        public long Id { get; set; }
    }
}
