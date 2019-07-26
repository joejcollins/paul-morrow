using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace coeusCapture
{
    [Route("api/[controller]")]    
    public class TodoController : ControllerBase
    {
            [HttpGet]
        public IActionResult Get()
        {            
            var b = System.IO.File.ReadAllBytes(@"C:\Users\a.doyle\Documents\Repos\coeus\camera-server\capture.png");   // You can use your own method over here.         
            return File(b, "image/jpeg");
        }
    }

}