using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shouts.Frontend.Models.Shouts
{
    public class ShoutListViewModel
    {
        public ShoutListViewModel(List<Shout> shouts)
        {
            Shouts = new List<Shout>();
            Shouts = shouts;
        }
        public List<Shout> Shouts { get; set; }
    }

    
}