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


        public IEnumerable<Topic> Get(bool includeReplies = false)
        {
            IQueryable<Topic> results;

            if (includeReplies)
            {
                results = _repo.GetTopicsIncludingReplies();
            }
            else
            {
                results = _repo.GetTopics();
            }

            return results.OrderByDescending(t => t.Created)
                            .Take(25)
                            .ToList();
        }

        public HttpResponseMessage Post([FromBody] Topic topic)
        {
            IQueryable<Topic> results = _repo.GetTopicsById(topic.Id);

            if (results.Count() > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Created, results);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // was Post
        public HttpResponseMessage Put([FromBody] Topic newTopic)
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