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
    public class TodoTaskService : ITodoTaskService
    {
        private readonly TodoTaskContext _context;
        public TodoTaskService(TodoTaskContext context)
        {
            _context = context;
        }
        public void CreateTodoTask(TodoTaskModel oTodoTaskModel)
        {
            if (oTodoTaskModel == null)
            {
                throw new ArgumentNullException(nameof(oTodoTaskModel));
            }

            _context.TodoTasks.Add(oTodoTaskModel);
        }

        public void DeleteTodoTask(TodoTaskModel oTodoTaskModel)
        {
            // validasi
            if (oTodoTaskModel == null)
            {
                throw new ArgumentNullException(nameof(oTodoTaskModel));
            }

            _context.TodoTasks.Remove(oTodoTaskModel);
        }

        public IEnumerable<TodoTaskModel> GetAllTodoTask()
        {
            return _context.TodoTasks.ToList();
        }

        public TodoTaskModel GetTodoTaskById(int id)
        {
            return _context.TodoTasks.FirstOrDefault(data => data.Id == id);
        }

        public IEnumerable<TodoTaskModel> GetTodoTaskToday()
        {
            DateTime todayDate = DateTime.Now.Date;
            return _context.TodoTasks.Where(data => data.Expired == todayDate).ToList();
        }

        public IEnumerable<TodoTaskModel> GetTodoTaskTomorrow()
        {
            DateTime tomorrow = DateTime.Now.Date;
            tomorrow = tomorrow.AddDays(1);
            return _context.TodoTasks.Where(data => data.Expired == tomorrow).ToList();
        }

        public IEnumerable<TodoTaskModel> GetTodoTaskWeek()
        {            
            DateTime startOfCurrentWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
            DateTime endOfCurrentWeek = startOfCurrentWeek.AddDays(7);
            return _context.TodoTasks.Where(data => data.Expired >= startOfCurrentWeek && data.Expired <= endOfCurrentWeek).ToList();            
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTodoTask(TodoTaskModel oTodoTaskModel)
        {
            // do nothing
        }
    }
}
