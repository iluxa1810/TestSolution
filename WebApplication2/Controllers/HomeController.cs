using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public enum DayTime
        {
            [Display(Name = "Утро")]
            Morning,
            [Display(Name = "День")]
            Afternoon,
            [Display(Name = "Вечер")]
            Evening,
            [Display(Name = "Ночь")]
            Night
        }
        public class DayTimeViewModel
        {
            public DayTime Period { get; set; }
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            //context.Result = Content("Internet Explorer не поддерживается");

            base.OnActionExecuting(context);
        }
        public IActionResult Index()
        {
            var ctx1 = ControllerContext;
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
