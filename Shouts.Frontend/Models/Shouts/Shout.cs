using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shouts.Frontend.Models.Shouts
{
    public class Shout
    {
        public Shout(string id, string content, string whenPosted)
        {
            this.id = id;
            this.content = content;
            this.whenPosted = whenPosted;
        }
        public string id { get; set; }
        public string content { get; set; }
        public string whenPosted { get; set; }
    }
}