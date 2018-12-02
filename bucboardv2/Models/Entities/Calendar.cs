using System;
using System.Collections.Generic;

namespace bucboardv2.Models.Entities
{
    public partial class Calendar
    {
        public Calendar()
        {
            Events = new HashSet<Events>();
        }

        public int CalendarId { get; set; }
        public string Month { get; set; }
        public int? UserId { get; set; }

        public Users User { get; set; }
        public ICollection<Events> Events { get; set; }
    }
}
