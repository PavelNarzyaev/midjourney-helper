using System;
using System.Collections.Generic;
using System.Text;

public class PromptPartImagesModel : PromptPartModelBase
{
    public List<ImageDto> notUsedImagesList => _notUsedImages.list;
    public List<ImageDto> usedImagesList => _usedImages.list;

    private ImagesListModel _notUsedImages = new();
    private ImagesListModel _usedImages = new();

    public override event Action changeEvent;

    public PromptPartImagesModel()
    {
        _notUsedImages.list = new List<ImageDto>
        {
            new() { link = "https://cdn.discordapp.com/attachments/1084173661474402305/1086032594530992149/1.jpg" },
            new() { link = "https://cdn.discordapp.com/attachments/1084173661474402305/1086032595105624186/2.jpg" }
        };
    }

    public override string GetPromptPart()
    {
        if (_usedImages.list.Count == 0)
            return string.Empty;

        var stringBuilder = new StringBuilder();
        foreach (var imageDto in _usedImages.list)
        {
            if (stringBuilder.Length != 0)
                stringBuilder.Append(" ");
            stringBuilder.Append(imageDto.link);
        }

        return stringBuilder.ToString();
    }

    public void MoveToUsed(string id)
    {
        var dto = _notUsedImages.GetById(id);
        _notUsedImages.Remove(dto);
        _usedImages.Add(dto);

        changeEvent?.Invoke();
    }

    public void MoveToUnused(string id)
    {
        var dto = _usedImages.GetById(id);
        _usedImages.Remove(dto);
        _notUsedImages.Add(dto);

        changeEvent?.Invoke();
    }
}
