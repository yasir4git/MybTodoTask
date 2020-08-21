# MybTodoTask

Your task is to create a REST api that will cover typical operations.
Object – ToDo task.

##### Minimal ToDo structure:
-   [X] Date and time of expiry
-   [X] Title
-   [X] Description
-   [X] % Complete


##### Required Operations:
-   [X] Get All Todo’s
    ```` javascript
    Method      : GET
    URL         : .../api/todo
    ````
-   [X] Get Specific Todo
    ```` javascript
    Method          : GET
    URL             : .../api/todo/{id}
    Parameter {id}  : (int) id of Todo Task item
    ````
-   [X] Get Incoming ToDo for today
    ```` javascript
    Method          : GET
    URL             : .../api/todo/today    
    ````
-   [X]Get Incoming ToDo for next day
    ```` javascript
    Method          : GET
    URL             : .../api/todo/next    
    ````
-   [X] Get Incoming ToDo for current week
    ```` javascript
    Method          : GET
    URL             : .../api/todo/week    
    ````
-   [X] Create Todo
    ```` javascript
    Method          : POST
    URL             : .../api/todo
    JSON body       : { string title, string description, date expired, int percentComplete }
    ````
-   [X] Update Todo
    ```` javascript
    Method          : PUT
    URL             : .../api/todo/{id}
    Parameter {id}  : (int) id of Todo Task item
    JSON body       : { string title, string description, date expired, int percentComplete }
    ````
-   [X] Set Todo percent complete
    ```` javascript
    Method          : PUT
    URL             : .../api/todo/{id}/setpros
    Parameter {id}  : (int) id of Todo Task item
    JSON body       : { int percentComplete }
    ````
-   [X] Delete Todo
    ```` javascript
    Method          : DELETE
    URL             : .../api/todo/{id}
    Parameter {id}  : (int) id of Todo Task item    
    ````
-   [X] Mark Todo as Done
    ```` javascript
    Method          : PUT
    URL             : .../api/todo/{id}/setdone
    Parameter {id}  : (int) id of Todo Task item    
    ````           
          
##### Requirements:
-   [x] .net Core 3.1
-   [x] data persisted MSSQL Server
      * set ConnectionString in appsettings.json as per required
        ```` javascript
        "ConnectionStrings": {
                    "SqlsrvDefault": "Server=localhost,1433;Initial Catalog=TodoTaskDB;User ID=me;Password=pass;"
                  }
        ````
      * run migration step via console
        ```` console
        dotnet ef database update
        ````      
-   [x] Nunit for unit tests
-   [ ] Commented code - not 100% commented.
-   [x] Code must be ready to compile and run
      * Set ConnectionString in appsettings.json as per required.
      * Run migration
      * Required package                
          - AutoMapper.Extensions.Microsoft.DependencyInjection
          - Microsoft.EntityFrameworkCore
          - Microsoft.EntityFrameworkCore.Design
          - Microsoft.EntityFrameworkCore.SqlServer
