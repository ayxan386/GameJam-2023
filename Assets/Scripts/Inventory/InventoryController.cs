using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] protected InventoryCellController[] itemCells;

    public static InventoryController Instance;

    protected int currentIndex = 0;

    void Awake()
    {
        Instance = this;
    }

    public virtual void AddItem(InventoryItem item)
    {
        itemCells[currentIndex++].SetItem(item);
    }
}