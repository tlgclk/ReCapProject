using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));
            if (result !=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = System.DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<CarImage> Get(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == imageId));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }
        public IDataResult<List<CarImage>> GetCarImages(int id)
        {
            IResult result = BusinessRules.Run(NullCarImage(id));
            if (result !=null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.Id == id));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));
            if (result !=null)
            {
                return result;
            }
            var formerPath = _carImageDal.Get(image => image.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelper.Update(formerPath, file);
            carImage.Date = System.DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var selectedCarImages = _carImageDal.GetAll(c => c.CarId == carId);
            if (selectedCarImages.Count >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> NullCarImage(int id)
        {
            try
            {
                string path = @"\wwwroot\images\default.jpg";
                var result = _carImageDal.GetAll(i => i.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> images = new List<CarImage>();
                    images.Add(new CarImage() { CarId = id, Date = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<CarImage>>(images);
                }

            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == id));
        }
    }
}
