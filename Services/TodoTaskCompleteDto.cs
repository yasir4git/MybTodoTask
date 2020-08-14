using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MybTodoTask.Services
{
    public class TodoTaskCompleteDto
    {
        [Required]
        [Range(1, 100)]
        public int PercentComplete { get; set; }
    }
}
