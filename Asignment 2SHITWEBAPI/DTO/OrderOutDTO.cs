﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asignment_2SHITWEBAPI.DTO
{
    public class OrderOutDTO
    {
        public int OrderID { get; set; }
        public string Username { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
