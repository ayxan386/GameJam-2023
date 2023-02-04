using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private Transform interactionPoint;

    private InteractableItem lastItem;

    void Update()
    {
        if (GlobalStateManager.FullscreenCanvas) return;
        var colliders = Physics.OverlapSphere(interactionPoint.position, maxDistance, interactionLayer);
        if (colliders != null
            && colliders.Length > 0
            && colliders[0].TryGetComponent(out InteractableItem item))
        {
            item.OnApproach();
            lastItem = item;
        }
        else
        {
            lastItem = null;
        }

        if (lastItem != null && Input.GetButtonDown("Fire1"))
        {
            lastItem.OnUsed();
        }
    }
}