using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPromptComponent : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Button button;
    [SerializeField] private CanvasGroup animationCanvasGroup;

    private void Start()
    {
        Model.ResultPrompt.changeEvent += RefreshText;
        button.onClick.AddListener(Model.ResultPrompt.CopyToClipboard);
        RefreshText();
        StartCoroutine(AnimationRoutine());
    }

    // ReSharper disable once IteratorNeverReturns
    private IEnumerator AnimationRoutine()
    {
        var targetAlpha = 0f;
        var animationSteps = 0;
        var currentStep = 0;
        var increasingDirection = animationCanvasGroup.alpha == 0;

        do
        {
            if (currentStep >= animationSteps)
            {
                currentStep = 0;
                var randomMultiplier = Random.Range(0.1f, 1f);
                if (increasingDirection)
                    targetAlpha = (1 - animationCanvasGroup.alpha) * randomMultiplier;
                else
                    targetAlpha = animationCanvasGroup.alpha * randomMultiplier;
                animationSteps = 480 + Random.Range(0, 60);
                increasingDirection = !increasingDirection;
            }

            var alpha = animationCanvasGroup.alpha;
            var alphaDistance = targetAlpha - alpha;
            var steps = animationSteps - currentStep;
            alpha += alphaDistance / steps;
            animationCanvasGroup.alpha = alpha;
            currentStep++;
            yield return null;
        } while (true);
    }

    private void RefreshText()
    {
        text.text = Model.ResultPrompt.text;
    }
}
