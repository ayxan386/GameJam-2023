using UnityEngine;

public class FlashbackItem : InteractableItem
{
    [SerializeField] private string flashbackId;
    [SerializeField] private bool folder = false;

    private bool wasUsed;

    public override void OnApproach()
    {
        if (FlashbackController.Instance.IsRunning || wasUsed) return;
        base.OnApproach();
        wasUsed = true;
        FlashbackController.Instance.PlayFlashBack(flashbackId);
    }
}