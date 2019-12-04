using System;
using System.Collections.Generic;

/// <summary>
/// This code demonstrates the Builder pattern in which different cars 
/// are assembled in a step-by-step fashion. The CarFactory uses 
/// CarBuilders to construct a two types of cars in a series of 
/// sequential steps.
/// </summary>
namespace Builder
{
    class Program
    {
        /// <summary>
        /// The Client
        /// </summary>
        static void Main(string[] args)
        {
            var superBuilder = new SuperCarBuilder();
            var notSuperBuilder = new NotSoSuperCarBuilder();

            var factory = new Carfactory();
            var builders = new List<CarBuilder> {
                                superBuilder, notSuperBuilder
            };

            foreach (var b in builders)
            {
                var c = factory.Build(b);
                Console.WriteLine($"The Car requested by " +
                    $"{b.GetType().Name}: " +
                    $"\n--------------------------------------" +
                    $"\nHorse Power: {c.HorsePower}" +
                    $"\nImpressive Feature: {c.MostImpressiveFeature}" +
                    $"\nTop Speed: {c.TopSpeedMPH} mph\n");
            }
        }
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    public class Car
    {
        public int TopSpeedMPH { get; set; }
        public int HorsePower { get; set; }
        public string MostImpressiveFeature { get; set; }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    public abstract class CarBuilder
    {
        protected readonly Car _car = new Car();
        public abstract void SetHorsePower();
        public abstract void SetTopSpeed();
        public abstract void SetImpressiveFeature();

        public virtual Car GetCar()
        {
            return _car;
        }
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    public class Carfactory
    {
        public Car Build(CarBuilder builder)
        {
            builder.SetHorsePower();
            builder.SetTopSpeed();
            builder.SetImpressiveFeature();
            return builder.GetCar();
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    public class NotSoSuperCarBuilder : CarBuilder
    {
        public override void SetHorsePower()
        {
            _car.HorsePower = 120;
        }
        public override void SetTopSpeed()
        {
            _car.TopSpeedMPH = 70;
        }
        public override void SetImpressiveFeature()
        {
            _car.MostImpressiveFeature = "Has Air Conditioning";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    public class SuperCarBuilder : CarBuilder
    {

        public override void SetHorsePower()
        {
            _car.HorsePower = 1640;
        }

        public override void SetTopSpeed()
        {
            _car.TopSpeedMPH = 600;
        }
        public override void SetImpressiveFeature()
        {
            _car.MostImpressiveFeature = "Can Fly";
        }

    }
}