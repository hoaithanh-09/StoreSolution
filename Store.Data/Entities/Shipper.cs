﻿using Store.Data.Entities.Common;
using System;
using System.Collections.Generic;

namespace Store.Data.Entities
{
    public class Shipper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public bool Gender { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Notification > Notifications { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}
