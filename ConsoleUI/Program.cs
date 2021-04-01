using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetailsTest();
            //ColorTest();
            //CustomerAddTest();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { Id = 1, UserId = 1, CompanyName = "Xiaomi" });
            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User {Id = 1, FirstName="Tolga", LastName="Çelik", Email="tolga@yandex.com", Password="123123" });

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName + "\n");
            }
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Car's Details :" + "\n" + car.BrandName + "\n" + car.ColorName + "\n" + car.DailyPrice + "\n" + car.CarName + "\n");
            }
        }


      
    }
}

