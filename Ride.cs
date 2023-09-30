using System;
using System.Collections.Generic;

public class Ride
{
    public Location StartLocation { get; set; }
    public Location EndLocation { get; set; }
    public int Price { get; set; }
    public Driver AssignedDriver { get; set; }
    public Passenger BookingPassenger { get; set; }

    public void AssignPassenger(Passenger passenger)
    {
        if (passenger != null)
        {
            BookingPassenger = passenger;
        }
        else
        {
            Console.WriteLine("Invalid passenger.");
        }
    }

    public bool AssignDriver(List<Driver> availableDrivers, string requestedRideType)
    {
        if (availableDrivers.Count == 0)
        {
            Console.WriteLine("No available drivers.");
            return false;
        }

        double minDistance = double.MaxValue;
        Driver closestDriver = null;

        foreach (var driver in availableDrivers)
        {
            if (driver != null && driver.Availability && driver.Vehicle != null &&
                driver.Vehicle.Type.Equals(requestedRideType, StringComparison.OrdinalIgnoreCase))
            {
                double distance = CalculateDistance(StartLocation, driver.CurrentLocation);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestDriver = driver;
                }
            }
        }

        if (closestDriver != null)
        {
            AssignedDriver = closestDriver;
            closestDriver.UpdateAvailability(false);
            Console.WriteLine($"Assigned driver: {closestDriver.Name}");
            return true; // Driver assignment was successful
        }
        else
        {
            Console.WriteLine($"No available {requestedRideType} drivers near the starting location.");
            return false; // Driver assignment failed
        }
    }


    public void SetLocations(Location startLocation, Location endLocation)
    {
        if (startLocation != null && endLocation != null)
        {
            StartLocation = startLocation;
            EndLocation = endLocation;
        }
        else
        {
            Console.WriteLine("Invalid locations.");
        }
    }

    public void CalculatePrice()
    {
        if (AssignedDriver == null)
        {
            Console.WriteLine("No assigned driver.");
            return;
        }

        if (AssignedDriver.Vehicle == null)
        {
            Console.WriteLine("Driver's vehicle information is missing.");
            return;
        }

        double distance = CalculateDistance(StartLocation, EndLocation);
        double fuelPrice = 2.0;
        double commission = 0.0;

        switch (AssignedDriver.Vehicle.Type)
        {
            case "Bike":
                commission = 0.05;
                break;
            case "Rickshaw":
                commission = 0.10;
                break;
            case "Car":
                commission = 0.20;
                break;
            default:
                Console.WriteLine("Invalid vehicle type.");
                return;
        }

        double ridePrice = (distance * fuelPrice / GetFuelAverage(AssignedDriver.Vehicle.Type)) + (distance * commission);
        Price = (int)Math.Round(ridePrice);
    }


    private double CalculateDistance(Location location1, Location location2)
    {
        if (location1 != null && location2 != null)
        {
            double latitudeDifference = location1.Latitude - location2.Latitude;
            double longitudeDifference = location1.Longitude - location2.Longitude;
            return Math.Sqrt(latitudeDifference * latitudeDifference + longitudeDifference * longitudeDifference);
        }
        else
        {
            Console.WriteLine("Invalid locations for distance calculation.");
            return 0.0;
        }
    }

    private double GetFuelAverage(string vehicleType)
    {
        switch (vehicleType)
        {
            case "Bike":
                return 50.0;
            case "Rickshaw":
                return 35.0;
            case "Car":
                return 15.0;
            default:
                Console.WriteLine("Invalid vehicle type for fuel average.");
                return 0.0;
        }
    }
}
