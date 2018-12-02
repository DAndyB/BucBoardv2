using System;
using System.Collections.Generic;

namespace bucboardv2.Models.Entities
{
    public partial class Premade
    {
        public int? EventType { get; set; }
        public int EventId { get; set; }

        public Events Event { get; set; }
    }
}
