using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoordinateConverter
{
    /// <summary>
    /// Latitude Longitutde Radius
    /// </summary>
    /// <param name="lat"></param>
    /// <param name="lon"></param>
    /// <param name="r"></param>
    public static Vector3 LonLanConverter(float lat, float lon, float r)
    {
        float latRad = Mathf.Deg2Rad * lat;
        float lonRad = Mathf.Deg2Rad * lon;

        float x = r * Mathf.Sin(latRad) * Mathf.Cos(lonRad);
        float y = r * Mathf.Sin(latRad) * Mathf.Sin(lonRad);
        float z = r * Mathf.Cos(latRad);

        return new Vector3(x, y, z);
    }
}
