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
    }

    private void RefreshText()
    {
        text.text = Model.ResultPrompt.text;
    }
}
