﻿/**
* M. Yasir Burhan
* 2020 08 14
* TodoTask for Karya Murni Publisher
*/

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
    [Route("api/todo")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;
        private readonly IMapper _mapper;

        public TodoTasksController(ITodoTaskService todoTaskService, IMapper mapper)
        {
            _todoTaskService = todoTaskService;
            _mapper = mapper;
        }

        // GET: api/todo        
        [HttpGet]
        public ActionResult<IEnumerable<TodoTaskModel>> GetAllTodoTask()
        {
            IEnumerable<TodoTaskModel> response = _todoTaskService.GetAllTodoTask();
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

        // GET api/todo/5        
        [HttpGet("{id:int}", Name = "GetTodoTaskById")]
        public ActionResult<TodoTaskReadDto> GetTodoTaskById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            TodoTaskModel response = _todoTaskService.GetTodoTaskById(id);
            if (response != null)
            {
                return Ok(new
                {
                    success = true,
                    message = "Data fetched",
                    data = _mapper.Map<TodoTaskReadDto>(response)
                });
            }

            return BadRequest(new
            {
                success = false,
                message = "No Data"
            });
        }

        // GET api/todo/today       
        [HttpGet("today")]
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

        [HttpGet("next")]
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

        [HttpGet("week")]
        public ActionResult<TodoTaskReadDto> GetTodoTaskWeek()
        {
            IEnumerable<TodoTaskModel> response = _todoTaskService.GetTodoTaskWeek();
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

        // POST api/todo        
        [HttpPost]
        public ActionResult<TodoTaskReadDto> CreateTodoTask([FromBody] TodoTaskCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TodoTaskModel data = _mapper.Map<TodoTaskModel>(request);
            _todoTaskService.CreateTodoTask(data);

            if (_todoTaskService.SaveChanges())
            {
                //return data sesuai yang masuk
                TodoTaskReadDto response = _mapper.Map<TodoTaskReadDto>(data);
                return CreatedAtRoute(nameof(GetTodoTaskById),
                new { response.Id },
                new
                {
                    success = true,
                    message = "Data fetched",
                    data = response
                });
            }

            return BadRequest();
        }

        // PUT api/todo/1  
        [HttpPut("{id:int}", Name = "UpdateTodoTask")]
        public ActionResult<TodoTaskReadDto> UpdateTodoTask(int id, TodoTaskUpdateDto request)
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
                return Created(nameof(UpdateTodoTask), new
                {
                    success = true,
                    message = "Data updated"
                });
            }
            return BadRequest();
        }

        // PUT api/todo/1/setpros
        [HttpPut("{id:int}/setpros", Name = "UpdateTodoTaskPercent")]
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

        // PUT api/todo/1/setdone
        [HttpPut("{id:int}/setdone", Name = "UpdateTodoTaskDone")]
        public ActionResult<TodoTaskReadDto> UpdateTodoTaskDone(int id)
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

            oldData.PercentComplete = 100;

            if (_todoTaskService.SaveChanges())
            {
                return Created(nameof(UpdateTodoTaskDone), new
                {
                    success = true,
                    message = "Data updated"
                });
            }
            return BadRequest();
        }

        // DELETE api/todo/5        
        [HttpDelete("{id}")]
        public ActionResult DeleteTodoTask(int id)
        {
            // ambil data existing sesuai ID
            TodoTaskModel oldData = _todoTaskService.GetTodoTaskById(id);
            if (oldData == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "No Data"
                });
            }

            _todoTaskService.DeleteTodoTask(oldData);
            _todoTaskService.SaveChanges();

            return Ok(
                new
                {
                    success = true,
                    message = "Data deleted"
                });
        }        
    }
}
