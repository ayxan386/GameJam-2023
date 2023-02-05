using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CurtainControl : MonoBehaviour
{
    [SerializeField] private float speed;
    private Image selfRef;

    private void Awake()
    {
        selfRef = GetComponent<Image>();
    }

    private void Update()
    {
        var curr = selfRef.color;
        curr.a -= speed * Time.deltaTime;
        if (curr.a <= 0)
        {
            Destroy(gameObject);
            return;
        }

        selfRef.color = curr;
    }
}