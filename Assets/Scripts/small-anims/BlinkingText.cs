using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float speed;
    [SerializeField] private float offset;

    private float curr = 0;

    void Update()
    {
        curr += speed * Time.deltaTime;
        if (curr > 1) curr = 0;
        text.alpha = Mathf.Sin((2 * Mathf.PI * curr + offset * Mathf.Deg2Rad));
    }
}