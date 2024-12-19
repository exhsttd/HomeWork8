namespace TaskManager.Classes;

public class Project
{
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public Employee Initiator { get; set; }
    public Employee TeamLead { get; set; }
    public List<Task> Tasks { get; set; }
    public ProjectStatus Status { get; set; }

    public Project(string description, DateTime deadline, Employee initiator, Employee teamLead)
    {
        Description = description;
        Deadline = deadline;
        Initiator = initiator;
        TeamLead = teamLead;
        Tasks = new List<Task>();
        Status = ProjectStatus.Projection;
    }

    public void StartProject()
    {
        if (Status == ProjectStatus.Projection)
        {
            Status = ProjectStatus.InProgress;
        }
    }

    public bool AllTasksCompleted()
    {
        foreach (var task in Tasks)
        {
            if (task.Status != TaskStatus.Completed)
            {
                return false;
            }
        }
        return true;
    }

    public void CloseProject()
    {
        if (AllTasksCompleted())
        {
            Status = ProjectStatus.Closed;
        }
    }
}
