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
            new() { link = "link1" },
            new() { link = "link2" }
        };

        usedImages.list = new List<ImageDto>
        {
            new() { link = "link3" },
            new() { link = "link4" }
        };
    }

    public override string GetPromptPart()
    {
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
