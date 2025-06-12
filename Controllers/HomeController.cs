using Microsoft.AspNetCore.Mvc;
using MvcTodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcTodoApp.Controllers
{
    public class HomeController : Controller
    {
        //  قائمة محلية تمثل قاعدة البيانات المؤقتة
        private static List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "تدرب على MVC Design Pattern", IsComplete = false },
            new TaskItem { Id = 2, Title = "تدرب على N-tier Architecture", IsComplete = false },
            new TaskItem { Id = 3, Title = "تدرب على استخدام git", IsComplete = false },
        };

        //  استرجاع القائمة
        public IActionResult Index()
        {
            return View(tasks);
        }

        //  إضافة مهمة
        [HttpPost]
        public IActionResult AddTask(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                int newId = tasks.Max(t => t.Id) + 1;
                var newTask = new TaskItem { Id = newId, Title = title, IsComplete = false };
                tasks.Add(newTask);
            }
            return RedirectToAction("Index");
        }

        //  تحديث حالة المهمة
        [HttpPost]
        public IActionResult CompleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
                task.IsComplete = true;
            return RedirectToAction("Index");
        }
        //تعديل حالة المهمة 

        [HttpGet]
public IActionResult EditTask(int id)
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task == null)
        return NotFound();
    return View(task);
}

[HttpPost]
public IActionResult EditTask(TaskItem model)
{
    var task = tasks.FirstOrDefault(t => t.Id == model.Id);
    if (task != null && !string.IsNullOrEmpty(model.Title))
    {
        task.Title = model.Title;
    }
    return RedirectToAction("Index");
}
    }
}
