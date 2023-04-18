using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Endpoint.Controllers
{
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        IMessageLogic logic;
        public MessageController(IMessageLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void Create([FromBody] Message value)
        {
            this.logic.Add(value);
        }

    }
}
