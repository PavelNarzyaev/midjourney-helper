using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private PromptComponentBase images;
    [SerializeField] private PromptComponentBase text;
    [SerializeField] private PromptComponentBase parameters;

    private void Start()
    {
        Debug.Log($"/imagine {images.GetResultString()} {text.GetResultString()} {parameters.GetResultString()}");
    }
}
