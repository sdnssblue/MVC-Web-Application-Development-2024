using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_LAB_2.Models;

namespace MVC_LAB_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaskModel _taskModel;

        public HomeController(ILogger<HomeController> logger, TaskModel taskModel)
        {
            _logger = logger;
            _taskModel = taskModel;
        }

        public IActionResult Index()
        {
            var viewModel = new TaskModel
            {
                Groups = _taskModel.Groups
            };
            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult AddStudent(TaskModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Message = "Ошибка добавления студента.";
                viewModel.Groups = _taskModel.Groups;
                return View("Index", viewModel);
            }

            StudentModel newStudent = viewModel.NewStudent;

            if (IsSpecialStudent(newStudent))
            {
                viewModel.ShowGroups = true;
                viewModel.Groups = _taskModel.Groups;
                return View("Index", viewModel);
            }

            viewModel.ShowGroups = false;
            GroupModel group = GetOrCreateGroupByName(newStudent.GroupName);

            if (!AlreadyInGroup(newStudent, group))
            {
                group.Students.Add(newStudent);
                viewModel.Message = $"Студент: {newStudent.Surname} {newStudent.Name} {newStudent.Patronymic} - добавлен.";
                viewModel.NewStudent = new StudentModel();
            }
            else
            {
                viewModel.Message = "Этот студент уже добавлен в группу.";
            }

            viewModel.CurrentGroup = group;
            viewModel.Groups = _taskModel.Groups;
            return View("Index", viewModel);
        }

        private bool IsSpecialStudent(StudentModel student)
        {
            return student is { Surname: "Мурзин", Name: "Евгений", Patronymic: "Сергеевич" };
        }

        private GroupModel GetOrCreateGroupByName(string groupName)
        {
            var group = _taskModel.Groups.FirstOrDefault(g => g.Name == groupName);
            if (group == null)
            {
                group = new GroupModel(groupName);
                _taskModel.Groups.Add(group);
            }
            return group;
        }

        private bool AlreadyInGroup(StudentModel newStudent, GroupModel group)
        {
            return group.Students.Any(student => student.Surname == newStudent.Surname &&
                                                 student.Name == newStudent.Name &&
                                                 student.Patronymic == newStudent.Patronymic);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}