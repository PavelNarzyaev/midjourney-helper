using System.Collections.Generic;
using UnityEngine;

public class Images : MonoBehaviour
{
    private List<ImageDto> _images;

    public void Initialize(List<ImageDto> images)
    {
        _images = images;
    }

    public List<ImageDto> GetImages()
    {
        return _images;
    }
}
