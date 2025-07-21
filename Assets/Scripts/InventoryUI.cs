using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public InventoryManager inventory;
    public Text infoText;

    void OnEnable()
    {
        if(inventory != null)
            inventory.OnInventoryChanged += Refresh;
    }

    void OnDisable()
    {
        if(inventory != null)
            inventory.OnInventoryChanged -= Refresh;
    }

    void Start()
    {
        Refresh();
    }

    void Refresh()
    {
        Refresh(inventory);
    }

    void Refresh(InventoryManager inv)
    {
        if(infoText != null && inv != null)
        {
            infoText.text = $"Items: {inv.Items.Count}/{inv.slotLimit}\nWeight: {inv.CurrentWeight:F1}";
        }
    }
}
