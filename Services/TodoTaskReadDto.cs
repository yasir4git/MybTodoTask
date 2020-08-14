/**
* M. Yasir Burhan
* 2020 08 14
* TodoTask for Karya Murni Publisher
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MybTodoTask.Services
{
    public class TodoTaskReadDto
    {
        
        public int Id { get; set; }

       
        public string Title { get; set; }

     
        public string Description { get; set; }

       
        public DateTime Expired { get; set; }

     
        public int PercentComplete { get; set; }
    }
}
