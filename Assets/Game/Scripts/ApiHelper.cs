using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public static class ApiHelper
{
    public static Joke GetNewJoke()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.chucknorris.io/jokes/random");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        return JsonUtility.FromJson<Joke>(json);
    }

    public static SpaceStationData GetLocation()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://api.open-notify.org/iss-now.json");

        request.Timeout = 5000; // Timeout in milliseconds

        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            return JsonUtility.FromJson<SpaceStationData>(json);
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.Timeout)
            {
                throw new TimeoutException("The request timed out.", ex);
            }
            else
            {
                throw;
            }
        }
    }

    public static RandomSatelite GetRandomLocation()
    {


        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.wheretheiss.at/v1/satellites/25544");

        request.Timeout = 5000; // Timeout in milliseconds

        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            RandomSatelite spaceStationData = JsonUtility.FromJson<RandomSatelite>(json);

            Debug.Log("Deserialized object: " + spaceStationData);
            Debug.Log("JSON data: " + json);

            return JsonUtility.FromJson<RandomSatelite>(json);
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.Timeout)
            {
                throw new TimeoutException("The request timed out.", ex);
            }
            else
            {
                throw;
            }
        }
    }
}
