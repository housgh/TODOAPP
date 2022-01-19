using System;

namespace TODOAPP.Domain.Models
{
    public class TODOTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual User User { get; set; }
    }
}