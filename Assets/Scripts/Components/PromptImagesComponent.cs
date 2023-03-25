using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PromptImagesComponent : MonoBehaviour
{
    [SerializeField] private TMP_InputField addInputField;
    [SerializeField] private Button addButton;
    [SerializeField] private ImageComponent originalImage;
    [SerializeField] private RectTransform imagesContainer;

    private Dictionary<string, ImageComponent> _imageComponentById = new();

    public void Start()
    {
        addButton.onClick.AddListener(OnAddButtonClick);
        Model.PromptPartImages.changeEvent += Refresh;
        originalImage.gameObject.SetActive(false);
        Refresh();
    }

    private void OnAddButtonClick()
    {
        Model.PromptPartImages.AddLink(addInputField.text.Trim());
        addInputField.text = string.Empty;
    }

    private void Refresh()
    {
        foreach (var imageComponent in _imageComponentById)
            imageComponent.Value.gameObject.SetActive(false);

        foreach (var image in Model.PlayerPrefs.currentState.imagesList)
        {
            var imageComponent = _imageComponentById.GetValueOrDefault(image.link);
            if (imageComponent == null)
            {
                imageComponent = Instantiate(originalImage, imagesContainer);
                imageComponent.gameObject.SetActive(true);
                imageComponent.SetLink(image.link);
                imageComponent.onClickComponentWithIdEvent += OnImageClick;
                imageComponent.onRemoveWithIdEvent += OnRemoveImageButtonClick;
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

    private void OnRemoveImageButtonClick(string id)
    {
        Model.PromptPartImages.RemoveByLink(id);
    }
}
