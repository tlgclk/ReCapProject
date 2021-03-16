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


            
            //brandManager.Add(new Brand { Id = 1, BrandName = "Volkswagen" });
            //brandManager.Add(new Brand { Id = 2, BrandName = "Renault" });

            //colorManager.Add(new Color { Id = 1, ColorName = "Kırmızı" });
            //colorManager.Add(new Color { Id = 2, ColorName = "Mavi" });
            //colorManager.Add(new Color { Id = 3, ColorName = "Yeşil" });

            //carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2013, DailyPrice = 200000, Descriptions = "Marka Volkswagen, rengi kırmızı" });
            //carManager.Add(new Car { Id = 2, BrandId = 1, ColorId = 2, ModelYear = 2008, DailyPrice = 130000, Descriptions = "Marka Volksvagen, rengi mavi" });
            //carManager.Add(new Car { Id = 3, BrandId = 1, ColorId = 2, ModelYear = 2015, DailyPrice = 150000, Descriptions = "Marka Volkswagen rengi mavi" });
            //carManager.Add(new Car { Id = 4, BrandId = 2, ColorId = 3, ModelYear = 2020, DailyPrice = 212500, Descriptions = "Marka Renault rengi yeşil" });
            //carManager.Add(new Car { Id = 5, BrandId = 2, ColorId = 3, ModelYear = 2018, DailyPrice = 141000, Descriptions = "Marka Renault rengi yeşil" });
            //carManager.Add(new Car { Id = 6, BrandId = 2, ColorId = 1, ModelYear = 2017, DailyPrice = 180000, Descriptions = "Renk : Kırmızı Marka: Renault" });


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
                Console.WriteLine("Cars -- " + "Name : " + cars.Descriptions + " -- Model Year : " + cars.ModelYear + " --  ID : " + cars.Id);
            }

        }
    }
}

