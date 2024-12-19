namespace TaskManager.Classes;

public class Task
{
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Employee Initiator { get; set; }
    public Employee Assignee { get; set; }
    public TaskStatus Status { get; set; }
    public Report TaskReport { get; set; }
    public TaskType Type { get; set; } // Тип задачи

    public Task(string description, DateTime dueDate, Employee initiator, TaskType type)
    {
        Description = description;
        DueDate = dueDate;
        Initiator = initiator;
        Type = type; 
        Status = TaskStatus.Assigned;
    }

    public void StartTask()
    {
        if (Status == TaskStatus.Assigned)
        {
            Status = TaskStatus.InProgress;
        }
    }

    public void FinishTask(string reportContent)
    {
        Status = TaskStatus.Completed;
        TaskReport = new Report
        {
            Content = reportContent,
            EndDate = DateTime.Now,
            Creator = Assignee
        };
    }
}
