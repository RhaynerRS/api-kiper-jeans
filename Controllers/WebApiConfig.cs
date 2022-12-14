using Microsoft.AspNetCore.Mvc;

namespace ApiMongoDb.Controllers
{
    [ApiController]
    public class DefaultController : Controller
    {
        [Route(""), HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public RedirectResult RedirectToSwaggerUi()
        {
            return Redirect("/swagger/index.html");
        }
    }
}