using System;
using System.Collections.Generic;

namespace bucboardv2.Models.Entities
{
    public partial class Recurring
    {
        public byte? IsAvalible { get; set; }
        public int EventId { get; set; }

        public Events Event { get; set; }
    }
}
