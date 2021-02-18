﻿using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        public int RentId { get; set; }
        public int CarId { get; set; }
        public int  UserId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}