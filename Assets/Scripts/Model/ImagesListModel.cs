using System.Collections.Generic;

public class ImagesListModel
{
    public List<ImageDto> list = new();

    public ImageDto GetById(string id)
    {
        return list[GetIndexById(id)];
    }

    private int GetIndexById(string id)
    {
        return list.FindIndex(imageDto => imageDto.link == id);
    }

    public void Add(ImageDto dto)
    {
        list.Add(dto);
    }

    public void Remove(ImageDto dto)
    {
        list.Remove(dto);
    }
}
