using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private PromptImagesComponent images;
    [SerializeField] private PromptTextComponent text;
    [SerializeField] private PromptParametersComponent parameters;

    public void Start()
    {
        var imagesPromptPart = Model.PromptPartImages;
        var textPromptPart = Model.PromptPartText;
        var parametersPromptPart = Model.PromptPartParameters;
        var promptPartModels = new List<PromptPartModelBase> { imagesPromptPart, textPromptPart, parametersPromptPart };
        var stringBuilder = new StringBuilder("/imagine prompt:");
        foreach (var promptPartModel in promptPartModels)
        {
            var promptPart = promptPartModel.GetPromptPart();
            if (!string.IsNullOrEmpty(promptPart))
                stringBuilder.Append($" {promptPart}");
        }
        Debug.Log(stringBuilder.ToString());
    }
}
