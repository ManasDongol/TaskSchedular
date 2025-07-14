
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using toDoList.Controllers.UserTasks.UserTasksDto;
using toDoList.Data;
using toDoList.Models;

namespace toDoList.Controllers.UserTasks;


[ApiController]
[Route("api/[controller]")]
public class UserTask : ControllerBase
{
    
    
    //creating db connection object
    public readonly ApplicationDbContext DbContext;

    public UserTask(ApplicationDbContext dbContext)
    {
        DbContext=dbContext;
    }

    [HttpGet]
    [EndpointName("getTasks")]
    [EndpointSummary("get user tasks")]
    [EndpointDescription("retreives all the tasks of the specific user")]
    public async Task<ActionResult<List<UserResponse>>> GetTasks()
    {
        var tasks=await DbContext.Tasks.ToListAsync();
        if (tasks.Count == 0 || tasks==null)
        {
            return NotFound();
        }
        var response= tasks.Select(UserResponse.From).ToList();
        return Ok(tasks);
        
    }

    [HttpPost]
    [EndpointName("AddTask")]
    [EndpointSummary("add task")]
    [EndpointDescription("add a new task")]
    public IActionResult AddTask([FromBody] CreateUserRequest userRequest)
    {
        var task1 = new Models.toDoTasks
        {
            Id = Guid.NewGuid(),
            Title = userRequest.Title,
            TaskDescription = userRequest.TaskDescription,
            TaskStatus = userRequest.TaskStatus,

        };
        DbContext.Add(task1);
        DbContext.SaveChanges();
        
        return Ok();
    }

    [HttpDelete( "{id:guid}")]

    [EndpointName("DeleteTask")]
    [EndpointSummary("delete task")]
    [EndpointDescription("delete task")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        var task = await DbContext.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        
        DbContext.Tasks.Remove(task);
        DbContext.SaveChanges();
        return Ok();
    }

    [HttpPut("{id:guid}")]
    [EndpointName("EditTask")]
    [EndpointSummary("Edit task")]
    [EndpointDescription("Edit any specific user")]
    public async Task<ActionResult<UserResponse>> editTask(Guid id,Models.toDoTasks userRequest)
    {
        var task = await DbContext.Tasks.FindAsync(id);
        task.Title=userRequest.Title;
        task.TaskDescription=userRequest.TaskDescription;
        task.TaskStatus=userRequest.TaskStatus;
        
        await DbContext.SaveChangesAsync();
        return NoContent();

    }
}