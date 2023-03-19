using UnityEngine;

public class PromptImagesComponent : MonoBehaviour
{
    [SerializeField] private ImagesListComponent notUsedImagesComponent;
    [SerializeField] private ImagesListComponent usedImagesComponent;

    public void Start()
    {
        notUsedImagesComponent.Refresh(Model.PromptPartImages.notUsedImages.list);
        notUsedImagesComponent.onClickImageWithIdEvent += OnNotUsedImageClick;
    }

    private void OnNotUsedImageClick(string id)
    {
        Debug.Log($"Click not used: «{id}»");
    }
}
