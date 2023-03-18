using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private PromptImagesComponent images;
    [SerializeField] private PromptTextComponent text;
    [SerializeField] private PromptParametersComponent parameters;

    public void Start()
    {
        var imagesPromptPart = Model.PromptPartImages.GetPromptPart();
        var textPromptPart = Model.PromptPartText.GetPromptPart();
        var parametersPromptPart = Model.PromptPartParameters.GetPromptPart();
        Debug.Log($"/imagine prompt: {imagesPromptPart} {textPromptPart} {parametersPromptPart}");
    }
}
