using UnityEngine;

public class Moveableitem : OneTimeDialogItem
{
    [SerializeField] private float forceFactor;
    [SerializeField] private int requiredClickCount;

    private Rigidbody rb;
    private int currentClickCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnUsed()
    {
        currentClickCount++;
        if (currentClickCount < requiredClickCount) return;
        currentClickCount = 0;
        var player = GameObject.Find("Player");
        if (player)
        {
            var forceDir = transform.position - player.transform.position;
            var randomFactor = Random.value;
            rb.AddForce(forceDir.normalized * (forceFactor * randomFactor), ForceMode.Impulse);
        }
    }
}