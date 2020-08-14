# MybTodoTask

Your task is to create a REST api that will cover typical operations.
Object – ToDo task.

Minimal ToDo structure:
    Date and time of expiry
    Title
    Description
    % Complete

 

 


Required Operations:

    Get All Todo’s  => GET: api/todo
    Get Specific Todo => GET api/todo/{id}
    Get Incoming ToDo
      for today => GET api/todo/today
      next day  => GET api/todo/next
      current week => GET api/todo/week
    Create Todo => POST api/todo                                => json from body [title, description, expired, percentComplete]
    Update Todo => PUT api/todo/{id}                            => json from body [title, description, expired, percentComplete]
    Set Todo percent complete => PUT api/todo/{id}/setpros      => json from body [percentComplete]
    Delete Todo => DELETE api/todo/{id}
    Mark Todo as Done => PUT api/todo/{id}/setdone
          
Requirements:

    .net Core >= 2.                     => .net Core 3.1
    data persisted (file, db)           => MSSQL db
      => set ConnectionString in appsettings.json as per required
          "ConnectionStrings": {
            "SqlsrvDefault": "Server=localhost,1433;Initial Catalog=TodoTaskDB;User ID=me;Password=pass;"
          }
      => run migration step. => dotnet ef database update
          
    nunit for unit tests  => NOT COMPLETED
    commented code        => NOT COMPLETED
    code must be ready to compile and run
      => set connection string
      => run migration
      => required package :
          AutoMapper.Extensions.Microsoft.DependencyInjection
          Microsoft.EntityFrameworkCore
          Microsoft.EntityFrameworkCore.Design
          Microsoft.EntityFrameworkCore.SqlServer
