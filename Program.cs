using System;
using System.Linq;
namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Welcome to MyRide");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("1. Book a Ride\n");
                Console.WriteLine("2. Enter as Driver\n");
                Console.WriteLine("3. Enter as Admin\n");
                Console.WriteLine("Press 1 to 3 to select an option: \n");

                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("Book a Ride");


                    Console.Write("Enter Name: ");
                    string passengerName = Console.ReadLine();

                    Console.Write("Enter Phone no: ");
                    string passengerPhoneNo = Console.ReadLine();

                    while (passengerPhoneNo.Length != 11 || !passengerPhoneNo.All(char.IsDigit))
                    {
                        Console.WriteLine("Invalid phone number. Please enter a valid 11-digit phone number without any hyphens:");
                        passengerPhoneNo = Console.ReadLine();
                    }

                    Console.Write("Enter Start Location (latitude,longitude): ");
                    string[] startLocationParts = Console.ReadLine().Split(',');
                    float startLatitude = float.Parse(startLocationParts[0]);
                    float startLongitude = float.Parse(startLocationParts[1]);
                    Location startLocation = new Location(startLatitude, startLongitude);

                    Console.Write("Enter End Location (latitude,longitude): ");
                    string[] endLocationParts = Console.ReadLine().Split(',');
                    float endLatitude = float.Parse(endLocationParts[0]);
                    float endLongitude = float.Parse(endLocationParts[1]);
                    Location endLocation = new Location(endLatitude, endLongitude);
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



                    Passenger passenger = new Passenger(passengerName, passengerPhoneNo);
                    passenger.BookRide(admin.driverList, startLocation, endLocation,vehicleType);
      

                }
                else if (option == "2")
                {
                    Console.WriteLine("Enter as Driver");

                    Driver Drivern = null;
                    bool flag = admin.SearchRDriver(out Drivern);
                    if( flag == true)
                    {
                        Console.WriteLine($"Hello! {Drivern.Name}");
                        Console.Write("Enter Current Location (latitude,longitude): ");
                        string[] cLocationParts = Console.ReadLine().Split(',');
                        float cLatitude = float.Parse(cLocationParts[0]);
                        float cLongitude = float.Parse(cLocationParts[1]);
                        Location cLocation = new Location(cLatitude, cLongitude);
                        Drivern.CurrentLocation = cLocation;
                        Console.WriteLine("1- Change Avaiabiltiy\n");
                        Console.WriteLine("2- Change Location\n");
                        Console.WriteLine("3- Exit\n");
                        
                        while (true)
                        {
                            string option1 = Console.ReadLine();
                            if (option1=="1")
                            {
                              
                                    Console.WriteLine("Are you avaiable?\n1- Yes\n2- No");
                                    int aoption = int.Parse(Console.ReadLine());
                                    if (aoption == 1) { Drivern.UpdateAvailability(true); Console.WriteLine("Availability Update Successfully"); break; }
                                    else if (aoption == 2) { Drivern.UpdateAvailability(false); Console.WriteLine("Availability Update Successfully"); break; }
                                    else{ Console.WriteLine("Invalid Option\n"); break; }
                                
                            }
                            else if (option1 == "2")
                            {
                                Console.WriteLine($"Hello! {Drivern.Name}");
                                Console.Write("Enter Current Location (latitude,longitude): ");
                                string[] uLocationParts = Console.ReadLine().Split(',');
                                float uLatitude = float.Parse(uLocationParts[0]);
                                float uLongitude = float.Parse(uLocationParts[1]);
                                Location uLocation = new Location(uLatitude, uLongitude);
                                Drivern.UpdateLocation(uLocation);
                                Console.WriteLine("Location Updated Successfully\n");
                            }
                            else if(option1 == "3")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice\n");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Driver Not Found!!!\n");
                        
                    }



                }
                else if (option == "3")
                {
                    Console.WriteLine("Enter as Admin");

                    while (true)
                    {
                        Console.WriteLine("Choose an option:");
                        Console.WriteLine("1. Add Driver");
                        Console.WriteLine("2. Update Driver");
                        Console.WriteLine("3. Remove Driver");
                        Console.WriteLine("4. Search Driver");
                        Console.WriteLine("5. Exit");

                        int choice = int.Parse(Console.ReadLine());

                        if (choice == 1)
                        {
                            admin.AddDriver();
                        }
                        else if (choice == 2)
                        {
                            admin.UpdateDriver();
                        }
                        else if (choice == 3)
                        {
                            admin.RemoveDriver();
                        }
                        else if (choice == 4)
                        {
                            admin.SearchDriver();
                        }
                        else if (choice == 5)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }
}
