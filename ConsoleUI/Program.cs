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
            // CarDetailsTest();
            //ColorTest();
            //CustomerAddTest();
            //BrandTest();

            UserManager userManager = new UserManager(new EfUserDal());
            User user2 = new User { Email = "amandacrs@gmail.com", FirstName = "Amanda", LastName = "Cruies", Password = "12345" };
            userManager.Add(user2);
            User user1 = new User { Email = "michaelq@gmail.com", FirstName = "Michael", LastName = "Bastor", Password = "12345" };
            userManager.Add(user1);
            
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

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName + "\n");
            }
        }
    }
}

