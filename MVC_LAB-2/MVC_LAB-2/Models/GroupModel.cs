namespace MVC_LAB_2.Models
{
    public class GroupModel
    {
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
        public string Name { get; set; } = string.Empty;

        public GroupModel(string newName)
        {
            Name = newName;
        }

        public GroupModel()
        {
        }
    }
}