using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using TaskManager.Entities;

namespace TaskManager.DataLayer
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base("TaskConnection")
        {
        }
        public DbSet<Task> Tasks { get; set; }
    }
}
