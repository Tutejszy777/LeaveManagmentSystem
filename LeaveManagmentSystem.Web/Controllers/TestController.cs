using Microsoft.AspNetCore.Mvc;

namespace LeaveManagmentSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var data = new Models.TestViewModel
            {
                Name = "That works",
                DateOfBirth = new DateTime(2003, 12, 23)
            };

            return View(data);
        }
    }
}
