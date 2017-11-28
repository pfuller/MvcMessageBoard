﻿using MessageBoardWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoardWebApp.Controllers
{
    public class RepliesController : ApiController
    {
        private IMessageBoardRepository _repo;

        public RepliesController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Reply> Get(int topicId)
        {
            return _repo.GetRepliesByTopic(topicId);
        }
    }
}
