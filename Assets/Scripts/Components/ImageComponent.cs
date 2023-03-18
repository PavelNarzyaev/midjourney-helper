using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageComponent : MonoBehaviour
{
    private string _currentLink;

    public void SetLink(string link)
    {
        if (!string.IsNullOrEmpty(_currentLink))
            GetComponent<Image>().sprite = null;

        _currentLink = link;

        StartCoroutine(DownloadImage());
    }

    private IEnumerator DownloadImage()
    {
        var request = UnityWebRequestTexture.GetTexture(_currentLink);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
            Debug.Log(request.error);
        else
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
            GetComponent<Image>().sprite = sprite;
        }
    }
}
