using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFinancialSummary : MonoBehaviour
{
    public void OnTapConfirm()
    {
        gameObject.SetActive(false);
        AdventureManager.instance.branch.Advance();
        AdventureManager.instance.Refresh();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
