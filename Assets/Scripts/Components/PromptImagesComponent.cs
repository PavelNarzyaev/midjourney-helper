using UnityEngine;

public class PromptImagesComponent : MonoBehaviour
{
    [SerializeField] private ImagesListComponent notUsedImagesComponent;
    [SerializeField] private ImagesListComponent usedImagesComponent;

    public void Start()
    {
        notUsedImagesComponent.Refresh(Model.PromptPartImages.notUsedImages.list);
    }
}
