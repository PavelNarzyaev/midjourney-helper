using System;
using System.Collections.Generic;
using UnityEngine;

public class ImagesListComponent : MonoBehaviour
{
    [SerializeField] private ImageComponent originalImage;
    [SerializeField] private RectTransform imagesContainer;

    private List<ImageComponent> _inactiveImagesPool = new();
    private List<ImageComponent> _activeImagesPool = new();

    public event Action<string> onClickImageWithIdEvent;

    private void Start()
    {
        originalImage.gameObject.SetActive(false);
    }

    public void Refresh(List<ImageDto> imagesDtos)
    {
        foreach (var image in _activeImagesPool)
        {
            image.gameObject.SetActive(false);
            _inactiveImagesPool.Add(image);
        }
        _activeImagesPool.Clear();

        foreach (var imageDto in imagesDtos)
        {
            ImageComponent image;
            if (_inactiveImagesPool.Count > 0)
            {
                var lastIndex = _inactiveImagesPool.Count - 1;
                image = _inactiveImagesPool[lastIndex];
                _inactiveImagesPool.RemoveAt(lastIndex);
            }
            else
            {
                image = Instantiate(originalImage, imagesContainer);
                image.onClickComponentWithIdEvent += OnImageClick;
            }

            image.gameObject.SetActive(true);
            image.SetLink(imageDto.link);
            _activeImagesPool.Add(image);
        }
    }

    private void OnImageClick(string id)
    {
        onClickImageWithIdEvent?.Invoke(id);
    }
}
