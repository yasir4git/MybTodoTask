using MybTodoTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MybTodoTask.Services
{
    public interface ITodoTaskService
    {
        void CreateTodoTask(TodoTaskModel oTodoTaskModel);
        IEnumerable<TodoTaskModel> GetAllTodoTask();
        TodoTaskModel GetTodoTaskById(int id);
        IEnumerable<TodoTaskModel> GetTodoTaskToday();
        IEnumerable<TodoTaskModel> GetTodoTaskTomorrow();
        IEnumerable<TodoTaskModel> GetTodoTaskWeek();
        void UpdateTodoTask(TodoTaskModel oTodoTaskModel);
        void DeleteTodoTask(TodoTaskModel oTodoTaskModel);
        bool SaveChanges();

        /*
        get incoming today, next day, current week
        get specific todo by title
        set todo percent complete
        mark todo as done
        */
    }
}
