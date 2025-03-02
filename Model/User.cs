using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string UserPassword { get; set; }

        public List<Task> TaskList { get; set; }
    }
}