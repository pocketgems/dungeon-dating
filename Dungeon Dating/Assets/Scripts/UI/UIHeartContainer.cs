using UnityEngine;

public class UIHeartContainer : MonoBehaviour
{
    public UIRelationshipSummary relationshipSummary;

    public GameObject star;
    public Transform heartSack;

    [HideInInspector]
    public bool isTappable = false;

    [HideInInspector]
    public int hearts = 0;

    public void OnTap()
    {
        if (isTappable)
        {
            relationshipSummary.FillHearts(hearts);
            hearts = 0;
            isTappable = false;
        }
    }

    private void Update()
    {
        star.SetActive(isTappable);

        if (isTappable)
        {
        }
        else
        {
            //heartSack.localPosition = Vector3.zero;
        }
    }
}
