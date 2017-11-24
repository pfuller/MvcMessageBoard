using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MessageBoardWebApp.Data
{
    public class MessageBoardMigrationsConfiguration : DbMigrationsConfiguration<MessageBoardContext>
    {
        public MessageBoardMigrationsConfiguration()
        {
#if DEBUG
            this.AutomaticMigrationDataLossAllowed = true;
#endif

            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoardContext context)
        {
            base.Seed(context);

#if DEBUG
            if(context.Topics.Count() == 0)
            {
                var topic1 = new Topic()
                {
                    Title = "MVC is great",
                    Created = DateTime.Now,
                    Body = "Wow isn't MVC so great and as a fanbee I can shut about it .. or my iPhone",
                    Replies = new List<Reply>()
                    {
                        new Reply()
                        {
                            Body = "Yeah it's the best",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "Papa don't preach",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "Adios mo fo",
                            Created = DateTime.Now
                        }
                    }
                };

                context.Topics.Add(topic1);

                var topic2 = new Topic()
                {
                    Title = "Javascript has matured",
                    Created = DateTime.Now,
                    Body = "I used to think javascript was a dying language but it has reinvented itseld",
                    Replies = new List<Reply>()
                    {
                        new Reply()
                        {
                            Body = "It's old failings have been fixed with type safety and dependency management",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "I'm stull unsure about it",
                            Created = DateTime.Now
                        }
                    }
                };

                context.Topics.Add(topic1);

                try
                {
                    context.SaveChanges();
                } catch (Exception e)
                {
                    var msg = e.Message;
                }
            }
#endif
        }
    }
}