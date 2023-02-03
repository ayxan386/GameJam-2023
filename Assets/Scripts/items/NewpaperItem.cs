using UnityEngine;

public class NewpaperItem : InteractableItem
{
    [SerializeField] private GameObject objRef;

    public override void OnUsed()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        objRef.SetActive(true);
    }

    public void Close()
    {
        objRef.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}