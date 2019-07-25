using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FaceAnalyser.Azure;
using Microsoft.Extensions.Configuration;

namespace FaceAnalyser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }

        public ImagesController(IConfiguration config)
        {
            Configuration = config;
        }

        // GET api/images
        [HttpGet]
        public ActionResult<string> Get()
        {
            return FaceAPI.MakeAnalysisRequest().Result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
