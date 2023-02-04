using UnityEngine;

public class Moveableitem : OneTimeDialogItem
{
    [SerializeField] private float forceFactor;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnUsed()
    {
        var player = GameObject.Find("Player");
        if (player)
        {
            var forceDir = transform.position - player.transform.position;
            var randomFactor = Random.value;
            rb.AddForce(forceDir.normalized * (forceFactor * randomFactor), ForceMode.Impulse);
        }
    }
}