using Microsoft.AspNetCore.Mvc;

namespace BigSchool.Controllers {
    public class CourseController : Controller {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
    {
        _logger = logger;
    }
    public ActionResult Courses() {
        return View();
    }
    [HttpGet]
    public ActionResult Create() {
        return View();
    }
    
    }
}
