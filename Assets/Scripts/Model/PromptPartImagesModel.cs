using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PromptPartImagesModel : PromptPartModelBase
{
    public List<ImageModel> imagesList;

    public override event Action changeEvent;

    public PromptPartImagesModel()
    {
        imagesList = new List<ImageModel>
        {
            new() { link = "https://cdn.discordapp.com/attachments/1084173661474402305/1086032594530992149/1.jpg" },
            new() { link = "https://cdn.discordapp.com/attachments/1084173661474402305/1086032595105624186/2.jpg" }
        };
    }

    public override string GetPromptPart()
    {
        if (imagesList == null || imagesList.Count == 0)
            return string.Empty;

        var selectedImages = imagesList.Where(image => image.selected);
        var stringBuilder = new StringBuilder();
        foreach (var image in selectedImages)
        {
            if (stringBuilder.Length != 0)
                stringBuilder.Append(" ");
            stringBuilder.Append(image.link);
        }

        return stringBuilder.ToString();
    }

    public void ChangeImageSelection(string id)
    {
        var image = GetById(id);
        image.selected = !image.selected;
        changeEvent?.Invoke();
    }

    private ImageModel GetById(string id)
    {
        return imagesList[GetIndexById(id)];
    }

    private int GetIndexById(string id)
    {
        return imagesList.FindIndex(imageDto => imageDto.link == id);
    }
}
