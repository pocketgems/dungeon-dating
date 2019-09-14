using UnityEngine;

public class UIPlayerHealthBar : MonoBehaviour
{
    public UIProgressBar progressBar;

    private void Update()
    {
        progressBar.Set(AdventureManager.instance.playerFighter.health, Player.instance.character.maxHealth);
    }
}
