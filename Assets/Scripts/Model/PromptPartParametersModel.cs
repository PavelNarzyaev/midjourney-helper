using System;

public class PromptPartParametersModel : PromptPartModelBase
{
    public override event Action changeEvent;

    public void SetText(string value)
    {
        Model.PlayerPrefs.currentState.parameters = value;
        Model.PlayerPrefs.Save();
        changeEvent?.Invoke();
    }

    public override string GetPromptPart()
    {
        return Model.PlayerPrefs.currentState.parameters;
    }
}
