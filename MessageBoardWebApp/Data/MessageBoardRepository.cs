using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoardWebApp.Data
{
    public class MessageBoardRepository : IMessageBoardRepository
    {
        MessageBoardContext _ctx;

        public MessageBoardRepository(MessageBoardContext ctx)
        {
            _ctx = ctx;
        }

        IQueryable<Topic> IMessageBoardRepository.GetTopics()
        {
            return _ctx.Topics;
        }

        IQueryable<Reply> IMessageBoardRepository.GetRepliesByTopic(int topicId)
        {
            return _ctx.Replies.Where(t => t.TopicId == topicId);
        }
    }
}