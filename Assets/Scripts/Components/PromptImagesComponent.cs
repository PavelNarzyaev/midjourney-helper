using UnityEngine;

public class PromptImagesComponent : MonoBehaviour
{
    [SerializeField] private ImagesListComponent notUsedImagesComponent;
    [SerializeField] private ImagesListComponent usedImagesComponent;

    public void Start()
    {
        notUsedImagesComponent.onClickImageWithIdEvent += OnNotUsedImageClick;
        usedImagesComponent.onClickImageWithIdEvent += OnUsedImageClick;
        Model.PromptPartImages.changeEvent += Refresh;

        Refresh();
    }

    private void OnNotUsedImageClick(string id)
    {
        Model.PromptPartImages.MoveToUsed(id);
    }

    private void OnUsedImageClick(string id)
    {
        Model.PromptPartImages.MoveToUnused(id);
    }

    private void Refresh()
    {
        notUsedImagesComponent.Refresh(Model.PromptPartImages.notUsedImagesList);
        usedImagesComponent.Refresh(Model.PromptPartImages.usedImagesList);
    }
}
