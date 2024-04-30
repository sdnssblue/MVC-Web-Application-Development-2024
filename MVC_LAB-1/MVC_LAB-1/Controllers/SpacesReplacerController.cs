using Microsoft.AspNetCore.Mvc;
using static MVC_LAB_1.Models.SpacesReplacerModel;

namespace MVC_LAB_1.Controllers
{
    public class SpacesReplacerController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReplaceSpaces(SentenceModel model)
        {
            if (model.InputText != null)
            {
                model.ReplacedText = model.InputText.Replace(" ", "_");
            }

            return View("Index", model);
        }
    }
}
