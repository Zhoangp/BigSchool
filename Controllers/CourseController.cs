using System.Security.Claims;
using BigSchool.Data;
using BigSchool.Models;
using BigSchool.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BigSchool.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public CourseController(ILogger<CourseController> logger, ApplicationDbContext dbcontext, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _dbContext = dbcontext;
            _logger = logger;
        }
        public ActionResult Courses()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.CategoryModel.ToList()
            };
            return View(viewModel);
        }
        public static List<string> GetErrorListFromModelState
                                              (ModelStateDictionary modelState)
        {
            var query = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;

            var errorList = query.ToList();
            return errorList;
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync(CourseViewModel viewModel)
        {
            Console.WriteLine(viewModel.Categories);
        
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                Console.WriteLine(GetErrorListFromModelState(ModelState)[0]);

                viewModel.Categories = _dbContext.CategoryModel.ToList();
                return View("Create", viewModel);
            }
            Console.WriteLine(viewModel.Category);
            CourseModel course = new CourseModel
            {
                LecturerId = userId,
                Datetime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.CourseModel.Add(course);
            _dbContext.SaveChanges();

            return Redirect("Success");
        }


        public ActionResult Success()
        {
            return View();
        }

    }
}
