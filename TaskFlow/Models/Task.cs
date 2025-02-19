using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskFlow.Models
{
    public class Task
    {
        public string TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskDesc { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UserId { get; set; }

    }
}