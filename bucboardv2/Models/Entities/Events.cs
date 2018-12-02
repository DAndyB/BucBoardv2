using System;
using System.Collections.Generic;

namespace bucboardv2.Models.Entities
{
    public partial class Events
    {
        public Events()
        {
            Messages = new HashSet<Messages>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? CalendarId { get; set; }

        public Calendar Calendar { get; set; }
        public CustomEvents CustomEvents { get; set; }
        public Premade Premade { get; set; }
        public Recurring Recurring { get; set; }
        public ICollection<Messages> Messages { get; set; }
    }
}
