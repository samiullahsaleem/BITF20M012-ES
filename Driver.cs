using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Driver
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Location CurrentLocation { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<int> Ratings { get; set; }
        public bool Availability { get; set; }

        public Driver(string id,string name, int age, string gender, string address, string phoneNumber, Location currentLocation, Vehicle vehicle)
        {
            ID = id;
            Name = name;
            Age = age;
            Gender = gender;
            Address = address;
            PhoneNumber = phoneNumber;
            CurrentLocation = currentLocation;
            Vehicle = vehicle;
            Ratings = new List<int>();
            Availability = true; // By default, the driver is available
        }

        public void UpdateAvailability(bool isAvailable)
        {
            Availability = isAvailable;
        }

        public double GetRating()
        {
            if (Ratings.Count == 0)
                return 0.0;

            int totalRating = 0;
            foreach (var rating in Ratings)
            {
                totalRating += rating;
            }

            return (double)totalRating / Ratings.Count;
        }

        public void UpdateLocation(Location newLocation)
        {
            CurrentLocation = newLocation;
        }
    }

