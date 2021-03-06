﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public bool IsCarAvailableInGivenStatus(int carId, DateTime rentDate, DateTime? returnDate)
        {
            using (RentCarContext context = new RentCarContext())
            {
                bool isCarExist = context.Set<Rental>().Any(
                    r => r.CarId == carId);
                bool isDatesAvailable = context.Set<Rental>().Any(r => (
                    (rentDate >= r.RentDate && rentDate <= r.ReturnDate) ||
                    (returnDate >= r.RentDate && returnDate <= r.ReturnDate) ||
                    (r.RentDate >= rentDate && r.RentDate <= returnDate)
                ));

                if (isCarExist&&isDatesAvailable)
                {
                    return true;
                }
                
                    return false;
                
            }
        }

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                    var result = 
                    from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars 
                             on rental.CarId equals car.CarId
                             join customer in context.Customers 
                             on rental.CustomerId equals customer.Id
                             join brand in context.Brands
                             on car.BrandId equals  brand.BrandId
                             join color in context.Colors 
                             on car.ColorId equals color.ColorId
                             join user in context.Users
                             on customer.UserId equals user.Id


                             select new RentalDetailDto
                             {
                                 CarId = car.CarId,
                                 RentId = rental.RentId,
                                 CustomerId = customer.Id,
                                 FirstName = user.FirstName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,
                                 BrandName = brand.BrandName,
                                 ModelYear = car.ModelYear,
                                 ColorName = color.ColorName,
                                 Description = car.Description,
                                 Email = user.Email,
                                 DailyPrice = car.DailyPrice,
                                 LastName = user.LastName,
                                 TotalPrice = rental.TotalPrice
                             };
                return result.ToList();

            }
        }
    }
}