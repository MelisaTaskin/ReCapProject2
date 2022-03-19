using Business.Abstract;
using Business.CCS;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;


        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //bir markadan en fazla 10 araba olabilir

            //aynı renkte  ürün eklenemez 

            //business codes
           IResult result = BusinessRules.Run(CheckIfCarOfColorExists(car.ColorId),
                CheckIfCarCountOfBrandCorrect(car.BrandId));
            if (result  != null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

            



        }

        public IResult Delete(Car car)
        {
            return new SuccessResult(Messages.CarAdded);
            //_carDal.Delete(car);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car>GetByDescription(string description)
        {
            return new SuccessDataResult<Car> (_carDal.Get(c=>c.Description==description));
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.CarId==id));
        }

        

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetail());
        }

        public IResult Update(Car car)
        {
            return new SuccessResult(Messages.CarAdded);
            //_carDal.Update(car);
        }


        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();

        }
        private IResult CheckIfCarOfColorExists(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId).Any();
            if (result==true)
            {
                return new ErrorResult(Messages.ColorIdAlreadyExists);
            }
            return new SuccessResult();
        }
    }





}
