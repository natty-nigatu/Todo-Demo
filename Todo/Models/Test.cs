using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public TodoItem Item { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
    }
}
