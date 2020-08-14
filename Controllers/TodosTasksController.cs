using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MybTodoTask.Models;
using MybTodoTask.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MybTodoTask.Controllers
{    
    [ApiController]
    public class TodosTasksController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly IMapper _mapper;

        public TodosTasksController(ITodoTaskService todoTaskService, IMapper mapper)
        {
            _todoTaskService = todoTaskService;
            _mapper = mapper;
        }

        // GET api/todo/today    
        [Route("api/todo/today")]
        [HttpGet]
        public ActionResult<TodoTaskReadDto> GetTodoTaskToday()
        {
            IEnumerable<TodoTaskModel> response = _todoTaskService.GetTodoTaskToday();
            if (response != null)
            {
                return Ok(new
                {
                    success = true,
                    message = "Data fetched",
                    data = _mapper.Map<IEnumerable<TodoTaskReadDto>>(response)
                });
            }

            return BadRequest(new
            {
                success = false,
                message = "No Data"
            });
        }

        //// GET api/todo/next    
        [Route("api/todo/next")]
        [HttpGet]
        public ActionResult<TodoTaskReadDto> GetTodoTaskTomorrow()
        {
            IEnumerable<TodoTaskModel> response = _todoTaskService.GetTodoTaskTomorrow();
            if (response != null)
            {
                return Ok(new
                {
                    success = true,
                    message = "Data fetched",
                    data = _mapper.Map<IEnumerable<TodoTaskReadDto>>(response)
                });
            }

            return BadRequest(new
            {
                success = false,
                message = "No Data"
            });
        }

        /*
        // PUT api/todo/5
        [Route("api/todos")]
        [HttpGet("{id}", Name = "UpdateTodoTaskPercent")]
        public ActionResult<TodoTaskReadDto> UpdateTodoTaskPercent(int id, TodoTaskCompleteDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            // ambil data existing by id
            TodoTaskModel oldData = _todoTaskService.GetTodoTaskById(id);
            if (oldData == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "No Data"
                });
            }

            // mapping tanpa deklarasi tipe, guna mapping perubahan
            _mapper.Map(request, oldData);
            _todoTaskService.UpdateTodoTask(oldData); // do nothing

            if (_todoTaskService.SaveChanges())
            {
                return Created(nameof(UpdateTodoTaskPercent), new
                {
                    success = true,
                    message = "Data updated"
                });
            }
            return BadRequest();
        }
        */
    }
}
