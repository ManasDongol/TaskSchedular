using System.ComponentModel.DataAnnotations;

namespace toDoList.Models;

public class toDoTasks
{
    [Key]
    public Guid Id { get; set; }
    
    public String Title { get; set; }
    public String TaskStatus { get; set; }
    
    [MaxLength(400)]
    public string  TaskDescription { get; set; }


    public toDoTasks()
    {
    }

    public toDoTasks(string status, string description)
    {
        TaskStatus = status;
        TaskDescription = description;
    }
}