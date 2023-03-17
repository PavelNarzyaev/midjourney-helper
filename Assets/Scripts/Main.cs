using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private PromptBlock images;
    [SerializeField] private PromptBlock text;
    [SerializeField] private PromptBlock parameters;

    private void Start()
    {
        Debug.Log($"/imagine {images.GetResultString()} {text.GetResultString()} {parameters.GetResultString()}");
    }
}
