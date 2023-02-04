using UnityEngine;
using UnityEngine.Serialization;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask interactionLayer;

    [FormerlySerializedAs("interactionPoint")] [SerializeField]
    private Transform topInteractionPoint;

    [SerializeField] private Transform middleInteractionPoint;
    [SerializeField] private Transform lowInteractionPoint;
    [SerializeField] private GameObject canGrabbedRef;

    private InteractableItem lastItem;

    void Update()
    {
        if (GlobalStateManager.FullscreenCanvas) return;
        if (!CheckInteraction(topInteractionPoint))
        {
            if (!CheckInteraction(middleInteractionPoint))
            {
                CheckInteraction(lowInteractionPoint);
            }
        }

        if (lastItem != null && Input.GetButtonDown("Fire1"))
        {
            lastItem.OnUsed();
        }
    }

    private bool CheckInteraction(Transform interactionPoint)
    {
        var colliders = Physics.OverlapSphere(interactionPoint.position, maxDistance, interactionLayer);
        if (colliders != null
            && colliders.Length > 0
            && colliders[0].TryGetComponent(out InteractableItem item))
        {
            item.OnApproach();
            lastItem = item;
            return true;
        }

        lastItem = null;
        canGrabbedRef?.SetActive(false);

        return false;
    }
}