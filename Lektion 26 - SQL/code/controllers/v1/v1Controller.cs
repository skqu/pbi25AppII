using Microsoft.AspNetCore.Mvc;

namespace code.controllers.v1
{
    [ApiController]
    [Route("v1")]
    public class V1Controller : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> GetVersion()
        {

            return Ok("Version: 1.0.0");
        }
    }
}