[System.Serializable]
public class SpaceStationData
{
    public string message;
    public long timestamp;
    public SpaceStationPosition iss_position;
}

[System.Serializable]
public class SpaceStationPosition
{
    public string latitude;
    public string longitude;
}

public class RandomSatelite
{
    public string name;
    public int id;
    public float latitude;
    public float longitude;
    public double altitude;
    public double velocity;
    public string visibility;
    public double footprint;
    public int timestamp;
    public double daynum;
    public double solar_lat;
    public double solar_lon;
    public string units;
}
