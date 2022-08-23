using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsCompleted { get; set; } = false;

        public int abc { get; set; }

        public int b { get; set; }

        public Test Test { get; set; }
    }
}
