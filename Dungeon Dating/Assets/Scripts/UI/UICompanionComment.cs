using UnityEngine;
using UnityEngine.UI;

public class UICompanionComment : MonoBehaviour
{
    public UICompanionPortrait portrait;
    public Text text;

    private float secondsRemaining = 0.0f;
    private const float secondsToShow = 2.0f;

    public void Show(Companion companion, string message)
    {
        portrait.companion = companion;
        text.text = message;
        gameObject.SetActive(true);
        secondsRemaining = secondsToShow;
    }

    private void Update()
    {
        if (secondsRemaining > 0.0f)
        {
            secondsRemaining -= Time.deltaTime;

            if (secondsRemaining <= 0.0f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
