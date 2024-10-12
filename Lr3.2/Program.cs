using System;
using System.Collections.Generic;

public class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if (other == null) return false;
        return this.Name == other.Name && this.Engine == other.Engine && this.MaxSpeed == other.MaxSpeed;
    }

    public override bool Equals(object obj)
    {
        if (obj is Car car)
        {
            return Equals(car);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return (Name, Engine, MaxSpeed).GetHashCode();
    }
}

public class CarsCatalog
{
    private List<Car> cars;

    public CarsCatalog()
    {
        cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= cars.Count)
                throw new IndexOutOfRangeException("Invalid index");

            return $"{cars[index].Name} (Engine: {cars[index].Engine}, Max Speed: {cars[index].MaxSpeed} km/h)";
        }
    }

    public int Count => cars.Count;
}

class Program
{
    static void Main()
    {
        CarsCatalog catalog = new CarsCatalog();

        catalog.AddCar(new Car("BMW X5", "3.0L I6 Turbo", 250));  // 3.0L I6 Turbo, 250 км/ч
        catalog.AddCar(new Car("Audi A6", "2.0L I4 Turbo", 240));  // 2.0L I4 Turbo, 240 км/ч
        catalog.AddCar(new Car("Chevrolet Corvette", "6.2L V8", 330));  // 6.2L V8, 330 км/ч

        for (int i = 0; i < catalog.Count; i++)
        {
            Console.WriteLine(catalog[i]);
        }

        Car car1 = new Car("BMW X5", "3.0L I6 Turbo", 250);
        Car car2 = new Car("BMW X5", "3.0L I6 Turbo", 250);
        Console.WriteLine($"equal? {car1.Equals(car2)}");
    }
}
