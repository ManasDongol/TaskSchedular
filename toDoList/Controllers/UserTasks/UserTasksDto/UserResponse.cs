using System.ComponentModel;

namespace toDoList.Controllers.UserTasks.UserTasksDto;

public sealed record UserResponse(
    [property: Description("the id of the user")]
    Guid id,
    [property: Description("The title of the tasks")]
    string title,

    [property: Description("The status of the task")]
    string TaskStatus,
    [property: Description("The description of the tasks")]
    string description
)
{
    
    public static UserResponse From(Models.toDoTasks toDoTasks)
        => new(toDoTasks.Id, toDoTasks.Title, toDoTasks.TaskStatus, toDoTasks.TaskDescription);

}


