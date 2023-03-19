using TMPro;
using UnityEngine;

public class PromptParametersComponent : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    private void Start()
    {
        inputField.text = Model.PromptPartParameters.GetPromptPart();
        inputField.onValueChanged.AddListener(value => Model.PromptPartParameters.SetText(value));
    }
}
