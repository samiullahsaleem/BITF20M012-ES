public class Vehicle
{
    public string Type { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }

    public Vehicle(string type, string model, string licensePlate)
    {
        Type = type;
        Model = model;
        LicensePlate = licensePlate;
    }
}