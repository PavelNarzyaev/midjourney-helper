using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PromptImagesComponent : PromptComponentBase
{
    [SerializeField] private ImagesListComponent notUsedImagesComponent;
    [SerializeField] private ImagesListComponent usedImagesComponent;

    public void Start()
    {
        notUsedImagesComponent.Initialize(new List<ImageDto>
        {
            new()
            {
                link = "link1"
            },
            new()
            {
                link = "link2"
            }
        });
    }

    public override string GetResultString()
    {
        var resultStringBuilder = new StringBuilder();
        foreach (var image in notUsedImagesComponent.GetImages())
        {
            if (resultStringBuilder.Length != 0)
                resultStringBuilder.Append(" ");
            resultStringBuilder.Append(image.link);
        }

        return resultStringBuilder.ToString();
    }
}
