using System;

public class PromptPartTextModel : PromptPartModelBase
{
    private string _text;
    public override event Action changeEvent;

    public void SetText(string value)
    {
        _text = value;
        changeEvent?.Invoke();
    }

    public override string GetPromptPart()
    {
        return _text;
    }
}
