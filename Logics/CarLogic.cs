using ProjectWinformCarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWinformCarDealer.Logics
{
    internal class CarLogic
    {
        public List<Car> getAllCar()
        {
            using (var context = new ProjectWinformContext())
            {
                return context.Cars.ToList();
            }
        }
        public Car getCarById(int id)
        {
            var context = new ProjectWinformContext();
            return context.Cars.FirstOrDefault(c => c.CarId == id);

        }
        public int addCar(Car c)
        {
            var context = new ProjectWinformContext();
            context.Cars.Add(c);
            return context.SaveChanges();

        }
        public int updateCar(Car cr)
        {
            var context = new ProjectWinformContext();
            Car old = context.Cars.FirstOrDefault(c => c.CarId == cr.CarId);
            if (old == null) return 0;

            old.Name = cr.Name;
            old.Model = cr.Model;
            old.Design = cr.Design;
            old.Chair = cr.Chair;
            old.Price = cr.Price;
            old.Wattage = cr.Wattage;
            old.MaximumTorque = cr.MaximumTorque;
            old.Acceleration = cr.Acceleration;
            old.MaxSpeed = cr.MaxSpeed;
            old.Fuel = cr.Fuel;
            old.Co2Emissions = cr.Co2Emissions;
            old.Tall = cr.Tall;
            old.Wide = cr.Wide;
            old.Long = cr.Long;
            old.Wheelbase = cr.Wheelbase;
            old.ImageLink = cr.ImageLink;

            return context.SaveChanges();

        }
        public int deleteCar(int id)
        {
            var context = new ProjectWinformContext();
            Car car = context.Cars.FirstOrDefault(c => c.CarId == id);
            if (car != null)
            {
                context.Cars.Remove(car);
            }
            return context.SaveChanges();
        }
    }
}
