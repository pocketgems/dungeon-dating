using UnityEngine;
using UnityEngine.UI;

public class UIJourneyProgressView : MonoBehaviour
{
    public Image progressBar;
    public Text progressLabel;

    public Transform start;
    public Transform finish;
    public Transform avatar;

    private void Update()
    {
        var mainBranch = AdventureManager.instance.dungeon.mainBranch;
        int progress = mainBranch.situationIndex;
        int total = mainBranch.situations.Count - 1;
        progressBar.fillAmount = (float)progress / total;
        progressLabel.text = progress + " / " + total;
        avatar.position = new Vector3(start.position.x + mainBranch.situationIndex * (finish.position.x - start.position.x) / total, avatar.position.y, avatar.position.z);
    }
}
