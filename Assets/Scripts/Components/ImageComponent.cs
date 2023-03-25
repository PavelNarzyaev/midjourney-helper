using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageComponent : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Image image;
    [SerializeField] private RectTransform imageRectTransform;
    [SerializeField] private Button button;
    [SerializeField] private Button removeButton;
    [SerializeField] private GameObject selectedMark;

    private string _currentLink;

    public event Action<string> onClickComponentWithIdEvent;
    public event Action<string> onRemoveWithIdEvent;

    private void Start()
    {
        button.onClick.AddListener(() => onClickComponentWithIdEvent?.Invoke(_currentLink));
        removeButton.onClick.AddListener(() => onRemoveWithIdEvent?.Invoke(_currentLink));
    }

    public void SetSelected(bool value)
    {
        selectedMark.SetActive(value);
    }

    public void SetLink(string link)
    {
        if (!string.IsNullOrEmpty(_currentLink))
            image.sprite = null;

        _currentLink = link;

        var loadedTexture = Model.LoadedImagesModel.textureByLink.GetValueOrDefault(_currentLink);
        if (loadedTexture == null)
            StartCoroutine(DownloadImage());
        else
            ApplyTexture(loadedTexture);
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
            Model.LoadedImagesModel.textureByLink.Add(_currentLink, texture);
            ApplyTexture(texture);
        }
    }

    private void ApplyTexture(Texture2D texture)
    {
        var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
        image.sprite = sprite;

        /*
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
        */
    }
}
