using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Pusher.Hubs;
using System;

namespace Pusher.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PushController : ControllerBase
    {
        private IHubContext<PushHub> _hubContext;

        public PushController(IHubContext<PushHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public string Get(string msg)
        {
            string retMessage = string.Empty;
            try
            {
                _hubContext.Clients.All.SendAsync("ReceiveMessage", "Hi", msg);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }

        [HttpPost]
        public string Add([FromBody]ConnectionData connectionData)
        {

            string retMessage = string.Empty;
            try
            {
                _hubContext.Groups.AddToGroupAsync(connectionData.Cid, connectionData.GroupId);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }

        [HttpPost]
        public string Show([FromBody]PushMessage pushMessage)
        {
            string retMessage = string.Empty;
            try
            {
                _hubContext.Clients.Group(pushMessage.GroupId).SendAsync("Read", pushMessage.Msg);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }

    public class ConnectionData
    {
        public string Cid { get; set; }
        public string GroupId { get; set; }
    }
    public class PushMessage
    {
        public string Msg { get; set; }
        public string GroupId { get; set; }
    }
}