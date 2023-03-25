using System;
using System.Linq;
using System.Text;
using UnityEngine;

public class PromptPartImagesModel : PromptPartModelBase
{
    public override event Action changeEvent;

    public void AddLink(string link)
    {
        if (Model.PromptPartImages.HasImage(link))
        {
            Debug.LogError("This image has already added");
            return;
        }

        Model.PlayerPrefs.currentState.imagesList.Add(new ImageModel { link = link, selected = true });
        Model.PlayerPrefs.Save();
        changeEvent?.Invoke();
    }

    public void RemoveByLink(string link)
    {
        Model.PlayerPrefs.currentState.imagesList.RemoveAt(GetIndexById(link));
        Model.PlayerPrefs.Save();
        changeEvent?.Invoke();
    }

    public override string GetPromptPart()
    {
        var selectedImages = Model.PlayerPrefs.currentState.imagesList.Where(image => image.selected);
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
        Model.PlayerPrefs.Save();
        changeEvent?.Invoke();
    }

    private bool HasImage(string id)
    {
        return Model.PlayerPrefs.currentState.imagesList.FirstOrDefault(image => image.link == id) != null;
    }

    private ImageModel GetById(string id)
    {
        return Model.PlayerPrefs.currentState.imagesList[GetIndexById(id)];
    }

    private int GetIndexById(string id)
    {
        return Model.PlayerPrefs.currentState.imagesList.FindIndex(image => image.link == id);
    }
}
