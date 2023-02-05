using System.Collections;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogBox;
    [SerializeField] private GameObject dialogObj;

    public static DialogController Instance;

    void Awake()
    {
        Instance = this;
    }

    public void DisplayDialog(string message, float dialogDuration)
    {
        dialogObj.SetActive(true);
        dialogBox.text = message;
        StartCoroutine(DisableAfterAwhile(dialogDuration));
    }

    private IEnumerator DisableAfterAwhile(float dialogDuration)
    {
        yield return new WaitForSeconds(dialogDuration);
        dialogObj.SetActive(false);
    }
}