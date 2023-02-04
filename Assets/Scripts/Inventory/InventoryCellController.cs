using UnityEngine;
using UnityEngine.UI;

public class InventoryCellController : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    public InventoryItem currentItem;

    public void SetItem(InventoryItem item)
    {
        currentItem = item;
        if (item)
            itemIcon.sprite = item.InventoryIcon;
        else itemIcon.sprite = null;
    }
}