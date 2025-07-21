using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item = new Rope();

    void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            var player = other.GetComponent<PlayerController>();
            if(player != null && player.inventory.AddItem(item))
            {
                Destroy(gameObject);
            }
        }
    }
}
