using UnityEngine;

public class FlashbackItem : InteractableItem
{
    [SerializeField] private string flashbackId;

    private bool wasUsed;

    public override void OnApproach()
    {
        if (FlashbackController.Instance.IsRunning || wasUsed) return;
        base.OnApproach();
        wasUsed = true;
        FlashbackController.Instance.PlayFlashBack(flashbackId);
    }
}