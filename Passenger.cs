using System;
using System.Collections.Generic;
using System.Linq;

public class Passenger
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Passenger(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

    public void BookRide(List<Driver> availableDrivers, Location startLocation, Location endLocation, string requestedRideType)
    {
        List<Driver> availableDriversList = availableDrivers
            .Where(driver => driver.Availability)
            .ToList();

        if (availableDriversList.Count == 0)
        {
            Console.WriteLine("No available drivers.");
            return;
        }

        Driver selectedDriver = availableDriversList[0];

        Ride ride = new Ride();
        ride.SetLocations(startLocation, endLocation);

        
        ride.AssignPassenger(this);

  
        if (ride.AssignDriver(availableDriversList, requestedRideType))
        {
            
            ride.CalculatePrice();
            Console.WriteLine($"Ride booked with driver {ride.AssignedDriver.Name}.");
            Console.WriteLine($"Ride price: {ride.Price} USD");
            this.GiveRating();
        }
        else
        {
          
            Console.WriteLine("Ride booking failed due to no available drivers.");
        }

    }


    public int GiveRating()
        {
            int rating;
            do
            {
                Console.Write("Please provide a rating (1-5): ");
            } while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5);

            return rating;
        }
    }


