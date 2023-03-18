using UnityEngine;

public class PromptPartTextModel : PromptPartModelBase
{
    private string _text;

    public PromptPartTextModel()
    {

    }

    public void SetText(string value)
    {
        Debug.Log(value);
        _text = value;
    }

    public override string GetPromptPart()
    {
        return _text;
    }
}
