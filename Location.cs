public class Location
{
    public float Latitude { get; private set; }
    public float Longitude { get; private set; }

    public Location(float latitude, float longitude)
    {
        SetLocation(latitude, longitude);
    }

    public void SetLocation(float latitude, float longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
