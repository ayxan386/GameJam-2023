using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private string displayName;
    public string DisplayName => displayName;

    public virtual void OnUsed()
    {
        // DialogController.Instance.DisplayDialog("This looks interesting", 3);
    }

    public virtual void OnApproach()
    {
        DialogController.Instance.DisplayDialog("This looks interesting", 3);
    }
}