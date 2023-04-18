
using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Model;
using System.Collections.Generic;

namespace Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageLogic logic;
        IHubContext<SignalRHub> hub;

        public MessageController(IMessageLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpPost]
        public void Create([FromBody] Message value)
        {
            this.logic.Add(value);
            this.hub.Clients.All.SendAsync("MessageSendt", value);
        }

        [HttpGet]
        public IEnumerable<Message> ReadAll()
        {
            return this.logic.ReadAll();
        }

    }
}
