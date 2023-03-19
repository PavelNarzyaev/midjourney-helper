using System;
using System.Collections.Generic;
using System.Linq;
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
                image = _inactiveImagesPool.TakeLast(1).ToList()[0];
            else
            {
                image = Instantiate(originalImage, imagesContainer);
                _activeImagesPool.Add(image);
            }

            image.gameObject.SetActive(true);
            image.SetLink(imageDto.link);
            image.onClickComponentWithIdEvent += OnImageClick;
        }
    }

    private void OnImageClick(string id)
    {
        onClickImageWithIdEvent?.Invoke(id);
    }
}
