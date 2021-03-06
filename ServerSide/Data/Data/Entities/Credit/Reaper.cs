﻿using Data.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Credit
{
    public class Reaper : BaseEntity
    {
        public string HeadName { get; set; }
        public decimal Balance { get; set; }
        public decimal LastTonPrice { get; set; }
        public virtual IEnumerable<ReaperDetail> ReaperDetails { get; set; }
    }
}
