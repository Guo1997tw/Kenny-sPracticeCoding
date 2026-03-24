using Microsoft.AspNetCore.Mvc;

namespace ChatRoomPractise.Controllers
{
    public class ChatRoomController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}