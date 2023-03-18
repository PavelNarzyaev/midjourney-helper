using System;

public class PromptPartParametersModel : PromptPartModelBase
{
    public override event Action changeEvent;

    public PromptPartParametersModel()
    {
        
    }

    public override string GetPromptPart()
    {
        return "PARAMETERS";
    }
}
