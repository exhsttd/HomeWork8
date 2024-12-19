namespace TaskManager.Classes;

public class TaskManager
{
    public List<Project> Projects { get; set; }
    public TaskManager()
    {
        Projects = new List<Project>();
    }
    public void AddProject(Project project)
    {
        Projects.Add(project);
    }
}
