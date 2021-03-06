﻿using System.ComponentModel.DataAnnotations;
using Castle.DynamicProxy.Generators.Emitters;
using Core.Entities;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        [Key]
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public bool Available { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        
    }
}