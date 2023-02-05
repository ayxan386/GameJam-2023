using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private Sprite inventoryIcon;
    [SerializeField] private ItemGroup itemGroup;

    public Sprite InventoryIcon => inventoryIcon;
    public ItemGroup ItemGroup => itemGroup;
}

public enum ItemGroup
{
    Any,
    PuzzlePiece_Level1
}