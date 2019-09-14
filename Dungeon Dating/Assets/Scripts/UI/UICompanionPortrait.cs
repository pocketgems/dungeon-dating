using UnityEngine;
using UnityEngine.UI;

public class UICompanionPortrait : MonoBehaviour
{
    public Image body;
    public Image face;
    public Image outfit;
    public Image hair;

    private Companion _companion;
    public Companion companion
    {
        set
        {
            _companion = value;

            body.sprite = value.body;
            face.sprite = value.normalFace;
            outfit.sprite = value.outfit;
            hair.sprite = value.hair;
        }

        get
        {
            return _companion;
        }
    }
}
