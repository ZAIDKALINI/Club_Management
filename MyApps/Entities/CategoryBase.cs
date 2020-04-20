using System.ComponentModel.DataAnnotations;

namespace Entities
{
    abstract public class CategoryBase
    {
        [Key]
        public int Id_Category { get; set; }
        public string Name_Category { get; set; }
    }
}
