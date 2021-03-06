﻿/**
* M. Yasir Burhan
* 2020 08 14
* TodoTask for Karya Murni Publisher
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MybTodoTask.Models
{
    public class TodoTaskModel
    {        
        /**
         * TodoTaskModel
         * consist design for table TodoTasks in MSSQL         
         */

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public DateTime Expired { get; set; }

        [Required]
        [Range(0, 100)]
        public int PercentComplete { get; set; }
    }
}
