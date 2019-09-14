using UnityEngine;
using UnityEngine.UI;

public class UIChestView : MonoBehaviour
{
    public Text situationDescription;
    public Text requirementDescription;
    public Text inventoryDescription;

    private Chest _chest;
    public Chest chest
    {
        get
        {
            return _chest;
        }

        set
        {
            _chest = value;
            situationDescription.text = "You see a " + value.description + ".";
            if (value.key.HasValue)
            {
                var keyItemQuantity = value.key.Value;
                requirementDescription.text = "You need a " + keyItemQuantity.item.name.ToLower() + " to " + value.unlockDescription + ".";

                int quantityOwned = Player.instance.GetQuantity(keyItemQuantity.item).quantity;
                inventoryDescription.text = "You own " + quantityOwned + " " + keyItemQuantity.item.name.ToLower() + ((quantityOwned != 1) ? "s" : "") + ".";

                requirementDescription.gameObject.SetActive(true);
                inventoryDescription.gameObject.SetActive(true);
            }
            else
            {
                requirementDescription.gameObject.SetActive(false);
                inventoryDescription.gameObject.SetActive(false);
            }
        }
    }
}
