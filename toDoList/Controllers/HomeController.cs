using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using toDoList.Models;



namespace toDoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult  Index()
    {
        ICollection<toDoTasks> taskList = new List<toDoTasks>
        {
            new toDoTasks("pending", "this is the task I need"),
            new toDoTasks("completed", "wash the dishes"),
            new toDoTasks("pending", "clean the porch")
            
        };
        return View(taskList);
    }
}