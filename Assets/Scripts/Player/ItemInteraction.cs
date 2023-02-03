using TMPro;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private GameObject activeIndicator;
    [SerializeField] private TextMeshProUGUI itemNameDisplay;

    private InteractableItem lastItem;

    void Update()
    {
        if (GlobalStateManager.PlayingMiniGame) return;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, maxDistance,
                interactionLayer))
        {
            if (hitInfo.collider.TryGetComponent(out InteractableItem item))
            {
                lastItem = item;
                activeIndicator.SetActive(true);
                itemNameDisplay.text = item.DisplayName;
            }

         
        }
        else
        {
            lastItem = null;
            activeIndicator.SetActive(false);
        }

        if (Input.GetButtonDown("Use") && lastItem != null)
        {
            lastItem.OnUsed();
        }
    }
}