using UnityEngine;
using UnityEngine.Serialization;

public class PanelActivatingItem : InteractableItem
{
    [FormerlySerializedAs("objRef")] [SerializeField]
    private GameObject panelRef;

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