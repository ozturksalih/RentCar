﻿using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            // UserManager manager = new UserManager(new EfUserDal());
           // manager.AddUser(new User{FirstName = "Salih", LastName = "Ozturk", Email = "salabi@salabi.com", Password = "salabi"});
           RentalManager manager = new RentalManager(new EfRentalDal());
           //manager.AddRental(new Rental {CarId = 1, UserId = 1, RentDate = new DateTime(2021,02,18) });
           

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 90, Description = "Volkswagen Polo", Id = 1, ModelYear = "2016" });
            //carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 120, Description = "Ford Focus", Id = 2, ModelYear = "2018" });
            //carManager.Add(new Car { BrandId = 2, ColorId = 3, DailyPrice = 50, Description = "Toyota Yaris", Id = 3, ModelYear = "2017" });
            //carManager.Add(new Car { BrandId = 3, ColorId = 4, DailyPrice = 200, Description = "Tesla Model X", Id = 4, ModelYear = "2013" });
            var result = carManager.GetCarDetail();
            Console.WriteLine(result.Success);
            Console.WriteLine(result.Message);

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(
                        car.BrandName + "/" + car.DailyPrice + "/" + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
