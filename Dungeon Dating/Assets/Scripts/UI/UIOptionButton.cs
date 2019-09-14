using UnityEngine;
using UnityEngine.UI;

public class UIOptionButton : MonoBehaviour
{
    public Text label;
    public GameObject effectsContainer;

    private Option _option;
    public Option option
    {
        get
        {
            return _option;
        }

        set
        {
            _option = value;

            label.text = value.title;
            effectsContainer.SetActive(false);
        }
    }

    public void OnTap()
    {
        option.Execute();
        AdventureManager.instance.Refresh();
    }
}
