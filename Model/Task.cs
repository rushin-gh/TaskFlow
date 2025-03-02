﻿using System;

namespace Model
{
    public class Task
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public string TaskDesc { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UserId { get; set; }
    }
}