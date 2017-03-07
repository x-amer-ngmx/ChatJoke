using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatJoke.Models
{
    public class UsersModel
    {
        public string Name;
        public Guid Marcer;
    }

    public class ChatModel
    {
        public IEnumerable<UsersModel> Users { get; set; }

        public IEnumerable<StoryMessModel> StoryMessage { get; set; }
    }

    public class SendMessModel
    {
        public IEnumerable<UsersModel> Users { get; set; }
        public string Message { get; set; }
    }

    public class StoryMessModel
    {
        public UsersModel User { get; set; }
        public string Message { get; set; }
    }

}