using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageComponent : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Image image;
    [SerializeField] private RectTransform imageRectTransform;

    private string _currentLink;

    public void SetLink(string link)
    {
        if (!string.IsNullOrEmpty(_currentLink))
            image.sprite = null;

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
            image.sprite = sprite;

            var rect = rectTransform.rect;
            var widthFactor = rect.width / texture.width;
            var heightFactor = rect.height / texture.height;
            if (widthFactor > heightFactor)
            {
                imageRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rect.height);
                imageRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, texture.width * heightFactor);
            }
            else
            {
                imageRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rect.width);
                imageRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, texture.height * widthFactor);
            }
        }
    }
}
