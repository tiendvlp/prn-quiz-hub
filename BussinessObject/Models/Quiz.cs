using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int NumberOfQuestion { get; set; }
        public DateTime? Date { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
