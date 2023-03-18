using System;
using System.Collections.Generic;
using System.Text;

public class PromptPartImagesModel : PromptPartModelBase
{
    public ImagesListModel notUsedImages = new();
    public ImagesListModel usedImages = new();

    public event Action changeEvent;

    public PromptPartImagesModel()
    {
        notUsedImages.list = new List<ImageDto>
        {
            new() { link = "https://cdn.discordapp.com/attachments/1084173661474402305/1086032594530992149/1.jpg" },
            new() { link = "https://cdn.discordapp.com/attachments/1084173661474402305/1086032595105624186/2.jpg" }
        };
    }

    public override string GetPromptPart()
    {
        if (usedImages.list.Count == 0)
            return string.Empty;

        var stringBuilder = new StringBuilder();
        foreach (var imageDto in usedImages.list)
        {
            if (stringBuilder.Length != 0)
                stringBuilder.Append(" ");
            stringBuilder.Append(imageDto.link);
        }

        return stringBuilder.ToString();
    }
}
