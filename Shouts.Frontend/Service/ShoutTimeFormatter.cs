using System;
using System.Collections.Generic;
using Shouts.Domain;

namespace Shouts.Frontend.Service
{
    public class ShoutTimeFormatter
    {
        private List<Shout> _originalShoutsList;
        private List<Models.Shouts.Shout> _convertedShoutList;
        public ShoutTimeFormatter(List<Shout> shouts)
        {
            _originalShoutsList = shouts;
            _convertedShoutList = new List<Models.Shouts.Shout>();
        }

        public List<Models.Shouts.Shout> ConvertShoutList()
        {
            //Place oldest elements last
            _originalShoutsList.Reverse();
            List<Models.Shouts.Shout> convertedShouts;
            foreach(Shout shout in _originalShoutsList)
            {
                _convertedShoutList.Add(ConvertShout(shout));
            }
            return _convertedShoutList;
        }
        
        public static Models.Shouts.Shout ConvertShout(Shout shout)
        {
            string newTime = ConvertTime(shout.PostTime);

            return new Models.Shouts.Shout(shout.Id, shout.Content, newTime);
        }

        private static string ConvertTime(DateTime shoutTime)
        {
            TimeSpan postedAgo = DateTime.Now - shoutTime.ToLocalTime();
            if (postedAgo.TotalSeconds < 60) { return (int) postedAgo.TotalSeconds + " seconds ago";}
            if (postedAgo.TotalMinutes < 60) { return (int) postedAgo.TotalMinutes + " minutes ago"; }
            if (postedAgo.TotalHours < 24)   { return (int) postedAgo.TotalHours + " hours ago"; }
            else                             { return (int) postedAgo.TotalDays + " days ago"; }
        }

        //private static string ConvertMailto(string shoutId)
        //{
        //    string mailtoId = "mailto:" + shoutId;
        //    return mailtoId;
        //}
        
    }
}