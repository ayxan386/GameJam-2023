public class OneTimeDialogItem : InteractableItem
{
    private bool wasApproached = false;

    public override void OnApproach()
    {
        if (!wasApproached) base.OnApproach();
        wasApproached = true;
        gameObject.layer = 0;
        Destroy(this);
    }
}