using UnityEngine;
using UnityEngine.Serialization;

public class PanelActivatingItem : InteractableItem
{
    [FormerlySerializedAs("objRef")] [SerializeField]
    private GameObject panelRef;

    [SerializeField] private GameObject grabRef;

    private bool dialogDisplayed;

    public override void PreUsed()
    {
    }

    public override void OnApproach()
    {
        grabRef.SetActive(true);
        if (dialogDisplayed) return;
        dialogDisplayed = true;
        base.OnApproach();
    }

    public override void OnUsed()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GlobalStateManager.FullscreenCanvas = true;
        panelRef.SetActive(true);
    }

    public void Close()
    {
        panelRef.SetActive(false);
        Cursor.visible = false;
        GlobalStateManager.FullscreenCanvas = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}