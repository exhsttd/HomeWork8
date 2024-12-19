using System;
using System.Collections.Generic;
using TaskManager.Classes;
using Task = TaskManager.Classes.Task;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new Classes.TaskManager();
            List<Employee> employees = new List<Employee>
            {
                new Employee("Олег"),
                new Employee("Сергей"),
                new Employee("Алексей"),
                new Employee("Анастасия"),
                new Employee("Дарья"),
                new Employee("Алена"),
                new Employee("Владимир"),
                new Employee("Владислав"),
                new Employee("Марина"),
                new Employee("Ольга")
            };
            
            Project project = new Project("Дизайн сайта компании по продаже котлет", DateTime.Now.AddMonths(1), employees[0], employees[1]);
            taskManager.AddProject(project);
            Console.WriteLine($"Проект: '{project.Description}'");
            
            var taskDescriptions = new List<string>
            {
                "Написание нового функционала",
                "Оптимизация производительности",
                "Настройка базы данных",
                "Дизайн логоптипа",
                "Дизайн пользовательского интерфейса",
                "Тестирование",
                "Интеграция с API",
                "Устранение ошибок",
                "Создание технической документации",
                "Проверка кода"
            };

            var taskTypes = new List<TaskType>
            {
                TaskType.Development,
                TaskType.Optimization,
                TaskType.Development,
                TaskType.Design,
                TaskType.Design,
                TaskType.Testing,
                TaskType.Integration,
                TaskType.Fixing,
                TaskType.Documentation,
                TaskType.Checking
            };

            for (int i = 0; i < taskDescriptions.Count; i++)
            {
                Task task = new Task(taskDescriptions[i], DateTime.Now.AddDays(10), employees[0], taskTypes[i]);
                project.Tasks.Add(task);
                task.Assignee = employees[i % employees.Count];
                Console.WriteLine($"Задача '{task.Description}' назначена работнику '{task.Assignee.Name}'.");
            }
            
            project.StartProject();
            Console.WriteLine();
            
            foreach (var task in project.Tasks)
            {
                task.StartTask();
            }
            
            foreach (var task in project.Tasks)
            {
                task.FinishTask("Отчет по " + task.Description);
            }
            project.CloseProject();
        
            Console.WriteLine($"Проект: '{project.Description}', статус проекта: {project.Status}");
            foreach (var task in project.Tasks)
            {
                Console.WriteLine($"Задача '{task.Description}', статус задачи: {task.Status}");
                Console.WriteLine($"Отчет: {task.TaskReport.Content}. Выполнен: {task.TaskReport.EndDate}");
            }
        }
    }
}