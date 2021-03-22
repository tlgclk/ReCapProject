﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetByBrandId(int id);
        List<Car> GetByColorId(int id);
        List<Car> GetByUnitPrice(decimal min,decimal max);
        List<CarDetailDto> GetCarDetails();

    }
}
