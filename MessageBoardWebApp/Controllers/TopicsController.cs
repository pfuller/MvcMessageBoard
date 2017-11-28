using MessageBoardWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoardWebApp.Controllers
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepository _repo;

        public TopicsController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }

        // text/xml
        // application/json


        public IEnumerable<Topic> Get()
        {
            return _repo.GetTopicsIncludingReplies()
                        .OrderByDescending(t => t.Created)
                        .Take(25)
                        .ToList();
        }

        public HttpResponseMessage Post([FromBody] Topic newTopic)
        {
            if(newTopic.Created == default(DateTime))
            {
                newTopic.Created = DateTime.UtcNow;
            }

            if(_repo.AddTopic(newTopic) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newTopic);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}