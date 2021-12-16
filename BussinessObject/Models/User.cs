using System;
using System.Collections.Generic;

#nullable disable

namespace BussinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Quizzes = new HashSet<Quiz>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
