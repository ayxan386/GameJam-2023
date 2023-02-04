using UnityEngine;

public class ObtainableItem : OneTimeDialogItem
{
    [SerializeField] private InventoryItem obtainedItemRef;
    [SerializeField] private GameObject indicatorRef;

    public override void OnApproach()
    {
        indicatorRef?.SetActive(true);
    }

    public override void OnUsed()
    {
        InventoryController.Instance.AddItem(obtainedItemRef);
        gameObject.SetActive(false);
    }
}