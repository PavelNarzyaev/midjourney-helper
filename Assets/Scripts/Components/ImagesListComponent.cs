using System;
using System.Collections.Generic;
using UnityEngine;

public class ImagesListComponent : MonoBehaviour
{
    [SerializeField] private ImageComponent originalImage;
    [SerializeField] private RectTransform imagesContainer;

    private Dictionary<string, ImageComponent> _imageComponentById = new();

    public event Action<string> onClickImageWithIdEvent;

    private void Start()
    {
        originalImage.gameObject.SetActive(false);
    }

    public void Refresh(List<ImageDto> imagesDtos)
    {
        foreach (var imageComponent in _imageComponentById)
            imageComponent.Value.gameObject.SetActive(false);

        foreach (var imageDto in imagesDtos)
        {
            var imageComponent = _imageComponentById.GetValueOrDefault(imageDto.link);
            if (imageComponent == null)
            {
                imageComponent = Instantiate(originalImage, imagesContainer);
                imageComponent.SetLink(imageDto.link);
                imageComponent.onClickComponentWithIdEvent += OnImageClick;
                _imageComponentById.Add(imageDto.link, imageComponent);
            }

            imageComponent.gameObject.SetActive(true);
        }
    }

    private void OnImageClick(string id)
    {
        onClickImageWithIdEvent?.Invoke(id);
    }
}
