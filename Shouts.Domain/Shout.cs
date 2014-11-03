using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shouts.Domain
{
    public class Shout
    {
        public Shout() { }

        public Shout(string id, string content, DateTime postTime)
        {
            this.Id = id;
            this.Content = content;
            this.PostTime = postTime;
        }
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
    }
}