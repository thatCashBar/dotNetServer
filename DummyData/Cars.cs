using System.Collections.Generic;
using dotNetServer.Models;

namespace dotNetServer.DummyData
{
    public class Cars
    {
        static private List<Car> cars = new List<Car>();
        static public List<Car> GetCars()
        {
            if (cars.Count > 0)
            {
                return cars;
            }
            cars.Add(
                new Car() {
                    Year = 2002,
                    Make = "Nissan",
                    Model = "Kicks SV",
                    Price = 17220,
                    Owner = "Jim Bob",
                    Color = "Black",
                    User = "user123"
                }
            );
            cars.Add(
                new Car() {
                    Year = 2021,
                    Make = "BMW",
                    Model = "X3 xDrive30i",
                    Price = 49085,
                    Owner = "James Johnson",
                    Color = "White",
                    User = "user888"
                }
            );
            cars.Add(
                new Car() {
                    Year = 2020,
                    Make = "Acura",
                    Model = "TLX Technology",
                    Price = 44525,
                    Owner = "Shelly Shelson",
                    Color = "Silver",
                    User = "user777"
                }
            );
            return cars;
        }

        static public List<Car> PostCar(Car car)
        {
            cars.Add(car);
            return cars;
        }

    }
}