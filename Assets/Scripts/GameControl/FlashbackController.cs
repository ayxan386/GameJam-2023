using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashbackController : MonoBehaviour
{
    [SerializeField] private FlashbackWrapper[] flashbacks;
    [SerializeField] private GameObject flashbackObj;
    [SerializeField] private Image imageRef;

    public static FlashbackController Instance;
    public bool IsRunning;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayFlashBack(string id)
    {
        foreach (var fl in flashbacks)
        {
            if (fl.id == id)
            {
                StartCoroutine(FlashbackCor(fl.images));
                break;
            }
        }
    }

    private IEnumerator FlashbackCor(FlashbackData[] images)
    {
        IsRunning = true;
        flashbackObj.SetActive(true);
        foreach (var image in images)
        {
            imageRef.sprite = image.sprite;
            yield return new WaitForSeconds(image.duration);
        }

        flashbackObj.SetActive(false);
        yield return new WaitForSeconds(5);
        IsRunning = false;
    }
}

[Serializable]
public struct FlashbackData
{
    public Sprite sprite;
    public float duration;
}

[Serializable]
public class FlashbackWrapper
{
    public FlashbackData[] images;
    public string id;
}