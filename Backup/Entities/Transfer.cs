﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Transfer
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public long DriverId { get; set; }
        public long FarmId { get; set; }
        public long StationId { get; set; }
        public decimal Nawlon { get; set; }
        public decimal Custody { get; set; }
        public decimal Withdraws { get; set; }
        public decimal Balance { get; set; }
        public string Notes { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Farm Farm { get; set; }
        public virtual Station Station { get; set; }
    }
}
