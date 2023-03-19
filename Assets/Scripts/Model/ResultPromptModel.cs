using System;
using System.Collections.Generic;
using System.Text;

public class ResultPromptModel
{
    public string text { get; private set; }
    public event Action changeEvent;
    private List<PromptPartModelBase> promptPartModels;

    public ResultPromptModel()
    {
        var imagesPromptPart = Model.PromptPartImages;
        var textPromptPart = Model.PromptPartText;
        var parametersPromptPart = Model.PromptPartParameters;
        promptPartModels = new List<PromptPartModelBase> { imagesPromptPart, textPromptPart, parametersPromptPart };

        foreach (var promptPartModel in promptPartModels)
            promptPartModel.changeEvent += Refresh;

        Refresh();
    }

    private void Refresh()
    {
        var stringBuilder = new StringBuilder("/imagine prompt:");
        foreach (var promptPartModel in promptPartModels)
        {
            var promptPart = promptPartModel.GetPromptPart();
            if (!string.IsNullOrEmpty(promptPart))
                stringBuilder.Append($" {promptPart}");
        }
        text = stringBuilder.ToString();

        changeEvent?.Invoke();
    }

    public void CopyToClipboard()
    {
        UniClipboard.SetText(text);
    }
}
