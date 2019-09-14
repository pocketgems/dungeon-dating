using UnityEngine;

public class UIIntro : MonoBehaviour
{
    public GameObject[] slides;

    private int slideIndex = 0;

    public void OnTapContinue()
    {
        slides[slideIndex++].SetActive(false);
        if (slideIndex < slides.Length)
        {
            slides[slideIndex].SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
