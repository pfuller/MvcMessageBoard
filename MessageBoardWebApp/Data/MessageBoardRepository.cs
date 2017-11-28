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

        bool IMessageBoardRepository.Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            } catch (Exception ex)
            {
                //TODO log error
                return false;
            }
        }

        bool IMessageBoardRepository.AddTopic(Topic newTopic)
        {
            try
            {
                _ctx.Topics.Add(newTopic);
                return true; 
            } catch (Exception e)
            {
                //TODO log error
                return false;
            }
        }

        IQueryable<Topic> IMessageBoardRepository.GetTopicsIncludingReplies()
        {
            return _ctx.Topics.Include("Replies");
        }
    }
}