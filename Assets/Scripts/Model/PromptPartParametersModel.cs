using System;

public class PromptPartParametersModel : PromptPartModelBase
{
    private string _text;
    public override event Action changeEvent;

    public PromptPartParametersModel()
    {
        _text = "--v 5 --iw 0.8 --s 500 --uplight --c 0";
    }

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
