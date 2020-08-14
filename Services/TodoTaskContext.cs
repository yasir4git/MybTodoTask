/**
* M. Yasir Burhan
* 2020 08 14
* TodoTask for Karya Murni Publisher
*/

using Microsoft.EntityFrameworkCore;
using MybTodoTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MybTodoTask.Services
{
    public class TodoTaskContext : DbContext
    {
        /**
         * TodoTaskContext
         * Database context for TodoTaskModel with MSSQL table TodoTasks in MSSQL         
         */

        public TodoTaskContext(DbContextOptions<TodoTaskContext> options) : base(options)
        {

        }

        public DbSet<TodoTaskModel> TodoTasks { get; set; }
    }
}
