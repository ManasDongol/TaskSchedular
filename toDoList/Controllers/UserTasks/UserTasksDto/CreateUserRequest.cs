using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace toDoList.Controllers.UserTasks.UserTasksDto;

public sealed record CreateUserRequest
(
    [Required]
    [MaxLength(100)]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
    [property:Description("the title of the to do list")]
    string Title,
    
    [Required]
    [MaxLength(100)]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed.")]
    [property:Description("the status of the to do list")]
    string  TaskStatus ,
    
    [Required]
    [MaxLength(500)]
    [property:Description("the description of the to do list")]
    string TaskDescription 
    
    
);