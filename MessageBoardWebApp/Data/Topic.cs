﻿using System;
using System.Collections.Generic;

namespace MessageBoardWebApp.Data
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}