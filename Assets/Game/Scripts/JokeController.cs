using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class JokeController : MonoBehaviour
{
      [SerializeField] private TextMeshProUGUI _jokeLabel;
      [SerializeField] private Button _generateJokeBtn;
      [SerializeField] private RawImage _jokeImage;

      private void Awake()
      {
            _generateJokeBtn.onClick.AddListener(GenerateJoke);
            _generateJokeBtn.onClick.AddListener(SetupImage);
      }

      private void GenerateJoke()
      {
            Joke joke = ApiHelper.GetNewJoke();
            _jokeLabel.text = joke.value;
      }

      private void SetupImage()
      {
            Joke jokeImage = ApiHelper.GetNewJoke();
            var image = jokeImage.icon_url;
            Debug.Log(image.ToString());
            StartCoroutine(LoadImageFromUrl("https://th.bing.com/th/id/OIP.H3gG6y-kBsh8bAM6ipclbAHaDl?pid=ImgDet&rs=1"));
      }

      private IEnumerator LoadImageFromUrl(string url)
      {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                  Debug.Log(www.error);
            }
            else
            {
                  Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                  _jokeImage.texture = texture;
            }
      }
}
