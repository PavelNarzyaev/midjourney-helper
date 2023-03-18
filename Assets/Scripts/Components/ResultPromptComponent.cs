using TMPro;
using UnityEngine;

public class ResultPromptComponent : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        Model.ResultPrompt.changeEvent += RefreshText;
    }

    private void RefreshText()
    {
        text.text = Model.ResultPrompt.text;
    }
}
