using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //Brand brand1 = new Brand();
            //brand1.Name = "citroen";


            //BrandManager brandManager = new BrandManager(new EfBrandDal());

            //brandManager.Add(brand1);





            BrandTest();



            CarTest();

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarId+"/"+car.BrandId);
            }

            //Car car1 = carManager.GetByDescription("Honda");
            //Console.WriteLine(car1.ColorId);
        }
    }
}
