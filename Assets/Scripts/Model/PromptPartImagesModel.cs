using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PromptPartImagesModel : PromptPartModelBase
{
    public List<ImageModel> imagesList = new();

    public override event Action changeEvent;

    public void AddLink(string link)
    {
        imagesList.Add(new ImageModel { link = link });
        changeEvent?.Invoke();
    }

    public void RemoveByLink(string link)
    {
        imagesList.RemoveAt(GetIndexById(link));
        changeEvent?.Invoke();
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
