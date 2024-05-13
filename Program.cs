using System;

namespace myFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Bicycle bicycle = new Bicycle();
            Boat boat = new Boat();
            car.speed = 100;
            Console.WriteLine("Car speed: {0}, wheels:{1}", car.speed, car.wheels);
            car.go();
            Console.WriteLine("bicycle speed: {0}, wheels:{1}", bicycle.speed, bicycle.wheels);
            bicycle.go();
            Console.WriteLine("boat speed: {0}, wheels:{1}", boat.speed, boat.wheels);
            boat.go();
            //Console.ReadKey();
        }
    }

    class Vehicle
    {
        public int speed = 0;

        public virtual void go() {
            Console.WriteLine("This Vehicle is moving!");
        }
    }

    class Car : Vehicle
    {
        public int wheels = 4;
        public override void go()
        {
            Console.WriteLine("Car is Rolling on {0} wheels",wheels);
        }
    }

    class Bicycle : Vehicle
    {
        public int wheels = 2;
    }

    class Boat : Vehicle
    {
        public int wheels = 0;
    }
}