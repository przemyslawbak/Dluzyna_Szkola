using Microsoft.AspNetCore.Mvc;

namespace DluzynaSzkola2.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error() => View();
    }
}
