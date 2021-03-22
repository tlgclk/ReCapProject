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
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //GetByBrandIdTest(carManager);

            // GetAllTest(carManager, brandManager, colorManager);

            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine("Car Name : " + carDetail.CarName + "\nBrand Name : " 
                    + carDetail.BrandName + "\nColor Name : " + carDetail.ColorName 
                    + "\nDaily Price : " + carDetail.DailyPrice + "\n\n\n");
            }

        }

        private static void GetByBrandIdTest(CarManager carManager)
        {
            foreach (var car in carManager.GetByBrandId(2))
            {
                Console.WriteLine("Car Name : " + car.CarName + "\nDaily Price : " + car.DailyPrice + "\n Description : " + car.Descriptions);
                Console.WriteLine("--------------");
            }
        }

        private static void GetAllTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            foreach (var brands in brandManager.GetAll())
            {
                Console.WriteLine("Brands -- " + "Name : " + brands.BrandName + "  ID : " + brands.Id);
            }

            Console.WriteLine();

            foreach (var colors in colorManager.GetAll())
            {
                Console.WriteLine("Colors -- " + "Name : " + colors.ColorName + "  ID : " + colors.Id);
            }

            Console.WriteLine();

            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine("Cars -- " + "Name : " + cars.Descriptions + " -- Model Year : " + cars.ModelYear + " --  ID : " + cars.Id + " -- Name : " + cars.CarName);
            }
        }
    }
}

