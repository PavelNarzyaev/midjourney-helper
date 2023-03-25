using System;

public class PromptPartTextModel : PromptPartModelBase
{
    public override event Action changeEvent;

    public void SetText(string value)
    {
        Model.PlayerPrefs.currentState.text = value;
        Model.PlayerPrefs.Save();
        changeEvent?.Invoke();
    }

    public override string GetPromptPart()
    {
        return Model.PlayerPrefs.currentState.text;
    }
}
