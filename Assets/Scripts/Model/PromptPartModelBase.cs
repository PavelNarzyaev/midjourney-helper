using System;

public abstract class PromptPartModelBase
{
    public abstract event Action changeEvent;
    public abstract string GetPromptPart();
}
