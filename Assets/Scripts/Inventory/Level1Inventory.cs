using UnityEngine;
using UnityEngine.Serialization;

public class Level1Inventory : InventoryController
{
    [FormerlySerializedAs("requiredNumberForNewsPaper")] [SerializeField]
    private int requiredNumberForId = 5;

    [SerializeField] private string idConnectionFlashBack;
    [SerializeField] private float flashbackRate;
    [SerializeField] private InventoryItem connectedId;
    public int newsPaperPieces;

    public override void AddItem(InventoryItem item)
    {
        base.AddItem(item);
        if (item.ItemGroup == ItemGroup.PuzzlePiece_Level1)
        {
            newsPaperPieces++;
        }

        if (newsPaperPieces == requiredNumberForId)
        {
            FlashbackController.Instance.PlayFlashBackInResources(idConnectionFlashBack, flashbackRate);
            foreach (var cell in itemCells)
            {
                if (cell.currentItem && cell.currentItem.ItemGroup == ItemGroup.PuzzlePiece_Level1)
                {
                    cell.SetItem(null);
                }
            }

            for (int i = 0; i < itemCells.Length; i++)
            {
                if (itemCells[i].currentItem == null)
                {
                    currentIndex = i;
                    break;
                }
            }

            base.AddItem(connectedId);
            DialogController.Instance.DisplayDialog("So this is who I am", 11);
        }
    }
}