using UnityEngine;
using UnityEngine.UI;

public class UIGenderChooser : MonoBehaviour
{
    public GameObject maleSelectionBorder;
    public GameObject femaleSelectionBorder;
    public Text confirmationLabel;
    public GameObject confirmationSection;

    public void OnTapMale()
    {
        maleSelectionBorder.SetActive(true);
        femaleSelectionBorder.SetActive(false);

        RefreshConfirmationLabel();
    }

    public void OnTapFemale()
    {
        maleSelectionBorder.SetActive(false);
        femaleSelectionBorder.SetActive(true);

        RefreshConfirmationLabel();
    }

    private void RefreshConfirmationLabel()
    {
        if (maleSelectionBorder.activeSelf)
        {
            confirmationLabel.text = "You are male. Is that correct?";
            confirmationSection.SetActive(true);
        }
        else if (femaleSelectionBorder.activeSelf)
        {
            confirmationLabel.text = "You are female. Is that correct?";
            confirmationSection.SetActive(true);
        }
        else
        {
            confirmationSection.SetActive(false);
        }
    }

    public void OnTapConfirmationButton()
    {
        if (maleSelectionBorder.activeSelf)
        {
            Player.instance.gender = Gender.Male;
        }
        else
        {
            Player.instance.gender = Gender.Female;
        }

        gameObject.SetActive(false);
    }
}
