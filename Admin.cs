using System;
using System.Collections.Generic;
using System.Linq;

public class Admin
{
    public List<Driver> driverList;

    public Admin()
    {
        driverList = new List<Driver>();
    }

    public void AddDriver()
    {
        Console.WriteLine("Enter Driver Details:");

        Console.Write("ID: ");
        string ID = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        int age;
        do
        {
            Console.Write("Age(Should be Positive): ");
        } while (!int.TryParse(Console.ReadLine(), out age) || age < 0);

        string gender;
        do
        {
            Console.Write("Gender (1 for Male, 2 for Female): (Should be from the Option)");
            string genderChoice = Console.ReadLine();
            if (genderChoice == "1")
            {
                gender = "Male";
                break;
            }
            else if (genderChoice == "2")
            {
                gender = "Female";
                break;
            }
        } while (true);

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();

        
        while (phoneNumber.Length != 11 || !phoneNumber.All(char.IsDigit))
        {
            Console.WriteLine("Invalid phone number. Please enter a valid 11-digit phone number without any hyphens:");
            phoneNumber = Console.ReadLine();
        }

        

        Console.Write("Current Latitude: ");
        float latitude;
        while (!float.TryParse(Console.ReadLine(), out latitude) || latitude < -90 || latitude > 90)
        {
            Console.Write("Invalid latitude. Please enter a valid latitude (-90 to 90): ");
        }

        Console.Write("Current Longitude: ");
        float longitude;
        while (!float.TryParse(Console.ReadLine(), out longitude) || longitude < -180 || longitude > 180)
        {
            Console.Write("Invalid longitude. Please enter a valid longitude (-180 to 180): ");
        }

        Location currentLocation = new Location(latitude, longitude);

        string vehicleType;
        do
        {
            Console.Write("Vehicle Type (1 for Car, 2 for Bike, 3 for Rickshaw): ");
            string typeChoice = Console.ReadLine();
            if (typeChoice == "1")
            {
                vehicleType = "Car";
                break;
            }
            else if (typeChoice == "2")
            {
                vehicleType = "Bike";
                break;
            }
            else if (typeChoice == "3")
            {
                vehicleType = "Rickshaw";
                break;
            }
        } while (true);

        Console.Write("Vehicle Model: ");
        string vehicleModel = Console.ReadLine();

        Console.Write("License Plate: ");
        string licensePlate = Console.ReadLine();

        Vehicle vehicle = new Vehicle(vehicleType, vehicleModel, licensePlate);

        Driver driver = new Driver(ID, name, age, gender, address, phoneNumber, currentLocation, vehicle);

        driverList.Add(driver);
        Console.WriteLine("Driver added successfully.");
    }

    public void UpdateDriver()
    {
        Console.WriteLine("Enter Driver ID to Update: ");
        string driverId = Console.ReadLine();

        Driver driver = driverList.FirstOrDefault(d => d.ID == driverId);

        if (driver == null)
        {
            Console.WriteLine("Driver not found.");
            return;
        }

        Console.WriteLine("Enter updated information (leave empty to skip):");

        Console.Write("Name: ");
        string name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
        {
            driver.Name = name;
        }

        Console.Write("Age: ");
        string ageInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(ageInput))
        {
            int age;
            while (!int.TryParse(ageInput, out age) || age < 0)
            {
                Console.Write("Invalid age. Please enter a valid age (>= 0): ");
                ageInput = Console.ReadLine();
            }
            driver.Age = age;
        }

        Console.Write("Gender (1 for Male, 2 for Female): ");
        string gender = Console.ReadLine();
        if (gender == "1")
        {
            driver.Gender = "Male";
        }
        else if (gender == "2")
        {
            driver.Gender = "Female";
        }

        Console.Write("Address: ");
        string address = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(address))
        {
            driver.Address = address;
        }

        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();

        // Validate the phone number
        while (phoneNumber.Length != 11 || !phoneNumber.All(char.IsDigit))
        {
            Console.WriteLine("Invalid phone number. Please enter a valid 11-digit phone number without any hyphens:");
            phoneNumber = Console.ReadLine();
        }


        if (!string.IsNullOrWhiteSpace(phoneNumber))
        {
            driver.PhoneNumber = phoneNumber;
        }

        Console.Write("Vehicle Type (1 for Car, 2 for Bike, 3 for Rickshaw): ");
        string vehicleType = Console.ReadLine();
        if (vehicleType == "1" || vehicleType == "2" || vehicleType == "3")
        {
            if (vehicleType == "1")
            {
                driver.Vehicle.Type = "Car";
            }
            else if (vehicleType == "2")
            {
                driver.Vehicle.Type = "Bike";
            }
            else if (vehicleType == "3")
            {
                driver.Vehicle.Type = "Rickshaw";
            }
        }

        Console.Write("Vehicle Model: ");
        string vehicleModel = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(vehicleModel))
        {
            driver.Vehicle.Model = vehicleModel;
        }

        Console.Write("License Plate: ");
        string licensePlate = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(licensePlate))
        {
            driver.Vehicle.LicensePlate = licensePlate;
        }

        Console.WriteLine("Driver updated successfully.");
    }

    public void RemoveDriver()
    {
        Console.WriteLine("Enter Driver ID to Remove: ");
        string driverId = Console.ReadLine();

        Driver driver = driverList.FirstOrDefault(d => d.ID == driverId);

        if (driver == null)
        {
            Console.WriteLine("Driver not found.");
            return;
        }

        driverList.Remove(driver);
        Console.WriteLine("Driver removed successfully.");
    }

    public void SearchDriver()
    {
        Console.WriteLine("Search Drivers by:");

        Console.Write("ID (leave empty to skip): ");
        string id = Console.ReadLine();

        Console.Write("Name (leave empty to skip): ");
        string name = Console.ReadLine();

        string ageInput;
        int? age = null;
        do
        {
            Console.Write("Age (leave empty to skip): ");
            ageInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                if (int.TryParse(ageInput, out int parsedAge) && parsedAge >= 0)
                {
                    age = parsedAge;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid age. Please enter a valid age (>= 0).");
                }
            }
            else
            {
                break;
            }
        } while (true);

        string gender;
        do
        {
            Console.Write("Gender (1 for Male, 2 for Female, leave empty to skip): (Should be from the option)\n");
            gender = Console.ReadLine();
        } while (!string.IsNullOrWhiteSpace(gender) && gender != "1" && gender != "2");

        Console.Write("Address (leave empty to skip): ");
        string address = Console.ReadLine();

        Console.Write("Phone Number (leave empty to skip): ");
        string phoneNumber = Console.ReadLine();

        // Validate the phone number
        while (phoneNumber.Length != 11 || !phoneNumber.All(char.IsDigit))
        {
            Console.WriteLine("Invalid phone number. Please enter a valid 11-digit phone number without any hyphens:");
            phoneNumber = Console.ReadLine();
        }

        

        string vehicleType;
        do
        {
            Console.Write("Vehicle Type (1 for Car, 2 for Bike, 3 for Rickshaw, leave empty to skip): ");
            vehicleType = Console.ReadLine();
        } while (!string.IsNullOrWhiteSpace(vehicleType) && vehicleType != "1" && vehicleType != "2" && vehicleType != "3");

        var filteredDrivers = driverList
            .Where(driver =>
                (string.IsNullOrWhiteSpace(id) || driver.Name.IndexOf(id, StringComparison.OrdinalIgnoreCase) >= 0) &&
                (string.IsNullOrWhiteSpace(name) || driver.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0) &&
                (!age.HasValue || driver.Age == age.Value) &&
                (string.IsNullOrWhiteSpace(gender) || (gender == "1" && driver.Gender == "Male") || (gender == "2" && driver.Gender == "Female")) &&
                (string.IsNullOrWhiteSpace(address) || driver.Address.IndexOf(address, StringComparison.OrdinalIgnoreCase) >= 0) &&
                (string.IsNullOrWhiteSpace(phoneNumber) || driver.PhoneNumber.Contains(phoneNumber)) &&
                (string.IsNullOrWhiteSpace(vehicleType) || ((vehicleType == "1" && driver.Vehicle.Type == "Car") || (vehicleType == "2" && driver.Vehicle.Type == "Bike") || (vehicleType == "3" && driver.Vehicle.Type == "Rickshaw")))
            )
            .ToList();

        DisplayDrivers(filteredDrivers);
    }

    private void DisplayDrivers(List<Driver> drivers)
    {
        Console.WriteLine("Driver ID\tName\tAge\tGender\tPhone Number\tAddress\tVehicle Type");
        foreach (var driver in drivers)
        {
            Console.WriteLine($"{driver.ID}\t{driver.Name}\t{driver.Age}\t{driver.Gender}\t{driver.PhoneNumber}\t{driver.Address}\t{driver.Vehicle.Type}");
        }
    }

    public bool SearchRDriver(out Driver foundDriver)
    {
        Console.Write("ID (leave empty to skip): ");
        string id = Console.ReadLine();
        Console.Write("Name (leave empty to skip): ");
        string name = Console.ReadLine();

        foundDriver = driverList.FirstOrDefault(driver =>
            (string.IsNullOrWhiteSpace(id) || driver.ID.Equals(id, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrWhiteSpace(name) || driver.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0));

        return foundDriver != null;
    }


}
