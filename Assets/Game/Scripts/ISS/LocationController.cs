using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationController : MonoBehaviour
{
    [SerializeField] private Button _getLocationBtn;
    [SerializeField] private float _earthRadius = 6371000f;
    [SerializeField] private Transform _redPoint;

    private void Awake()
    {
        _getLocationBtn.onClick.AddListener(GetRandomPosSatelite);
    }

    private void GetLocation()
    {
        SpaceStationData spaceStationData = ApiHelper.GetLocation();

        if (spaceStationData != null && spaceStationData.iss_position != null)
        {
            var longitude = spaceStationData.iss_position.longitude;
            var latitude = spaceStationData.iss_position.latitude;

            Vector3 targetPosition = CoordinateConverter.LonLanConverter(float.Parse(latitude), float.Parse(longitude), 10f);

            Debug.Log("Long Lat: " + longitude + " " + latitude);
            Debug.Log("Target pos: " + targetPosition);

            _redPoint.position = targetPosition;
        }
        else
        {
            Debug.LogError("Failed to retrieve ISS location data.");
        }
    }

    private void GetRandomPosSatelite()
    {
        RandomSatelite spaceStationData = ApiHelper.GetRandomLocation();

        if (spaceStationData != null)
        {
            var longitude = spaceStationData.longitude;
            var latitude = spaceStationData.latitude;

            Vector3 targetPosition = CoordinateConverter.LonLanConverter(latitude,longitude, 10f);

            Debug.Log("Long Lat: " + longitude + " " + latitude);
            Debug.Log("Target pos: " + targetPosition);

            _redPoint.position = targetPosition;
        }
        else
        {
            Debug.LogError("Failed to retrieve random satelite's location data.");
        }
    }

    // Function to convert longitude and latitude to world position
    public Vector3 ConvertCoordinatesToPosition(float longitude, float latitude)
    {
        // Convert longitude and latitude to radians
        float lonRad = Mathf.Deg2Rad * longitude;
        float latRad = Mathf.Deg2Rad * latitude;

        // Calculate the 3D position on the sphere
        float x = _earthRadius * Mathf.Sin(latRad) * Mathf.Cos(lonRad);
        float y = _earthRadius * Mathf.Cos(latRad);
        float z = _earthRadius * Mathf.Sin(latRad) * Mathf.Sin(lonRad);

        return new Vector3(x, y, z);
    }
}
