using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    public Image fill;
    public Text label;
    public bool showText;
    public string prefixText;

    public void Set(int progress, int max)
    {
        if (progress > max)
        {
            progress = max;
        }

        fill.fillAmount = (float)progress / max;

        if (showText)
        {
            label.text = prefixText + progress + " / " + max;
            label.gameObject.SetActive(true);
        }
        else
        {
            label.gameObject.SetActive(false);
        }
    }
}
