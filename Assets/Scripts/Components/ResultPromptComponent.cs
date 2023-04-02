using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPromptComponent : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button button;

    private void Start()
    {
        Model.ResultPrompt.changeEvent += RefreshText;
        button.onClick.AddListener(Model.ResultPrompt.CopyToClipboard);
        RefreshText();
    }

    private void RefreshText()
    {
        var processedText = new StringBuilder();
        var splitPrompt = Model.ResultPrompt.text.Split(' ');
        foreach (var splittedBySpacesPiece in splitPrompt)
        {
            if (string.IsNullOrEmpty(splittedBySpacesPiece))
                continue;

            if (processedText.Length > 0)
                processedText.Append(" ");

            if (splittedBySpacesPiece.Contains("http://") || splittedBySpacesPiece.Contains("https://"))
            {
                var splitLink = splittedBySpacesPiece.Split("/");
                processedText.Append($"[{splitLink.Last()}]");
            }
            else
                processedText.Append(splittedBySpacesPiece);
        }

        text.text = processedText.ToString();
    }
}
