using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;

public class ImagePromptsBlock : PromptBlock
{
    [FormerlySerializedAs("unusedImages")] [SerializeField] private Images notUsedImages;
    [SerializeField] private Images usedImages;

    public void Start()
    {
        notUsedImages.Initialize(new List<ImageDto>
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
        foreach (var image in notUsedImages.GetImages())
        {
            if (resultStringBuilder.Length != 0)
                resultStringBuilder.Append(" ");
            resultStringBuilder.Append(image.link);
        }

        return resultStringBuilder.ToString();
    }
}
