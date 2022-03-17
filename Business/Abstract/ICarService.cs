using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {




        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);

        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetById(int id);

        IDataResult<Car> GetByDescription(string description);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        object GetById(object id);
    }
}
