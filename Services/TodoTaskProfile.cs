/**
* M. Yasir Burhan
* 2020 08 14
* TodoTask for Karya Murni Publisher
*/
using AutoMapper;
using MybTodoTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MybTodoTask.Services
{
    public class TodoTaskProfile : Profile
    {
        public TodoTaskProfile()
        {
            // buat create
            CreateMap<TodoTaskCreateDto, TodoTaskModel>();
            // buat read
            CreateMap<TodoTaskModel, TodoTaskReadDto>();
            // buat set percent
            CreateMap<TodoTaskCompleteDto, TodoTaskModel>();
        }
    }
}
