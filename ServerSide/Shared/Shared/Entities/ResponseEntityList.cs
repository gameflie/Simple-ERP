﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Entities
{
    public class ResponseEntityList<T>
    {
        public int Total { get; set; }
        public List<T> List { get; set; }
    }
}
