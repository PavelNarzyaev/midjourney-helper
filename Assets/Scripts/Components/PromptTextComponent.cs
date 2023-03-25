using TMPro;
using UnityEngine;

public class PromptTextComponent : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    private void Start()
    {
        inputField.text = Model.PlayerPrefs.currentState.text;
        inputField.onValueChanged.AddListener(value => Model.PromptPartText.SetText(value));
    }
}
