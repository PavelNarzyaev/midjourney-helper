using System.Collections.Generic;
using UnityEngine;

public class PromptImagesComponent : MonoBehaviour
{
    [SerializeField] private ImageComponent originalImage;
    [SerializeField] private RectTransform imagesContainer;

    private Dictionary<string, ImageComponent> _imageComponentById = new();

    public void Start()
    {
        Model.PromptPartImages.changeEvent += Refresh;
        originalImage.gameObject.SetActive(false);
        Refresh();
    }

    private void Refresh()
    {
        foreach (var imageComponent in _imageComponentById)
            imageComponent.Value.gameObject.SetActive(false);

        foreach (var image in Model.PromptPartImages.imagesList)
        {
            var imageComponent = _imageComponentById.GetValueOrDefault(image.link);
            if (imageComponent == null)
            {
                imageComponent = Instantiate(originalImage, imagesContainer);
                imageComponent.gameObject.SetActive(true);
                imageComponent.SetLink(image.link);
                imageComponent.onClickComponentWithIdEvent += OnImageClick;
                _imageComponentById.Add(image.link, imageComponent);
            }
            else
                imageComponent.gameObject.SetActive(true);

            imageComponent.SetSelected(image.selected);

        }
    }

    private void OnImageClick(string id)
    {
        Model.PromptPartImages.ChangeImageSelection(id);
    }
}
