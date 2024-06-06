namespace MVC_LAB_2.Models
{
    public class TaskModel
    {
        public List<GroupModel> Groups { get; set; } = new List<GroupModel>();
        public StudentModel NewStudent { get; set; } = new StudentModel();
        public GroupModel CurrentGroup { get; set; } = new GroupModel();
        public bool ShowGroups { get; set; } = false;
        public string Message { get; set; } = string.Empty;

        public TaskModel(List<GroupModel> groups)
        {
            Groups = groups ?? new List<GroupModel>();
        }

        public TaskModel()
        {
        }
    }
}