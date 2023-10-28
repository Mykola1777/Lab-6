using System;



public abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }

    public Vehicle(int speed, int capacity)
    {
        Speed = speed;
        Capacity = capacity;
    }

    public abstract void Move();
}


public class Human : Vehicle
{
    public Human(int speed) : base(speed, 1) { }

    public override void Move()
    {
        Console.WriteLine("Walking");
    }
}


public class Car : Vehicle
{
    public Car(int speed, int capacity) : base(speed, capacity) { }

    public override void Move()
    {
        Console.WriteLine("Driving a car");
    }
}

public class Bus : Vehicle
{
    public Bus(int speed, int capacity) : base(speed, capacity) { }

    public override void Move()
    {
        Console.WriteLine("Taking a bus");
    }
}

public class Train : Vehicle
{
    public Train(int speed, int capacity) : base(speed, capacity) { }

    public override void Move()
    {
        Console.WriteLine("Riding a train");
    }
}


public class Route
{
    public string Start { get; set; }
    public string End { get; set; }

    public Route(string start, string end)
    {
        Start = start;
        End = end;
    }
}


public class TransportNetwork
{
    private List<Vehicle> vehicles;

    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void ControlMovement(Route route)
    {
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Moving from {route.Start} to {route.End}:");
            vehicle.Move();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Human human = new Human(5);
        Car car = new Car(60, 4);
        Bus bus = new Bus(40, 20);
        Train train = new Train(100, 200);

        Route route1 = new Route("City A", "City B");
        Route route2 = new Route("City X", "City Y");

        TransportNetwork transportNetwork = new TransportNetwork();
        transportNetwork.AddVehicle(human);
        transportNetwork.AddVehicle(car);
        transportNetwork.AddVehicle(bus);
        transportNetwork.AddVehicle(train);

        foreach (var vehicle in transportNetwork.vehicles)
        {
            Console.WriteLine($"Moving from {route1.Start} to {route1.End}:");
            vehicle.Move();

            Console.WriteLine($"Moving from {route2.Start} to {route2.End}:");
            vehicle.Move();
        }
    }
}
