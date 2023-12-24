using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class FristController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //url:Frist/Welcome
        [HttpGet]
        public async Task<string> Welcome()
        {
            return "Welcome From Frist Action";
        }

        public async Task<ContentResult> Welcome2()
        {
            ContentResult result = new ContentResult(); 
            result.Content = "Welcome From Frist Action";
            return result;
        }

        public async Task<ViewResult> GetData()
        {
            ViewResult view = new ViewResult();
            view.ViewName = "View";
            return view;
        }
    }
}
