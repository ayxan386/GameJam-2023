public class OneTimeDialogItem : InteractableItem
{
    private bool wasApproached = false;
    protected bool shouldDestroy;

    public override void OnApproach()
    {
        if (!wasApproached) base.OnApproach();
        wasApproached = true;
        gameObject.layer = 0;
        if (shouldDestroy)
            Destroy(this);
    }

    protected void SetDestroy(bool val)
    {
        shouldDestroy = val;
    }
}