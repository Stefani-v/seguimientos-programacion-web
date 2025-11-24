using Microsoft.AspNetCore.Mvc;
using To_doList.Models;

namespace To_doList.Controllers
{
    public class TasksController : Controller
    {
        public static List<TaskItem> tasks = new List<TaskItem>();
        private static int counter = 1;

        public IActionResult Index()
        {
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Add(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))//VALIDAMOS QUE LA DESCRIPCIÓN NO SEA NULA, O UN ESPACIO EN BLANCO O VACÍA
            {
                TaskItem task = new TaskItem();
                task.Id = counter++;//llama al Id para assignarle un número deacuerdo al número en que va avanzando el counter
                task.Description = description;
                tasks.Add(task);//se envía el task, es decir el model(TaskItem) a la lista tasks
            }
            return RedirectToAction("Index");//AQUÍ SE PASA A LA VISTA, VA A MOSTRAR LAS TAREAS
        }
        [HttpPost]
        public IActionResult ToggleComplete(int id)
        {
            TaskItem task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;//por defecto es false

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            TaskItem task = tasks.FirstOrDefault(t => t.Id == id);//El método de Linq es FirstOrDefault que busca el primer elemento que cumpla
            //la condición de para cada elemento t en la lista, verifica si su propiedad Id sea igual al id que recibimos y guarda el result en task
            if (task != null)
            {
                tasks.Remove(task);

            }
            return RedirectToAction("Index");
        }
    }
}
