using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashbackController : MonoBehaviour
{
    [SerializeField] private FlashbackWrapper[] flashbacks;
    [SerializeField] private GameObject flashbackObj;
    [SerializeField] private Image imageRef;
    [SerializeField] private AudioSource sfxSource;

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

    public void PlayFlashBackInResources(string folderName, float dur)
    {
        var loadAll = Resources.LoadAll("flashbacks/" + folderName, typeof(Sprite));
        if (loadAll != null)
        {
            var sprites = new Sprite[loadAll.Length];
            int k = 0;
            foreach (var obj in loadAll)
            {
                sprites[k++] = (Sprite)obj;
            }

            StartCoroutine(FlashbackCorForSprites(sprites, dur));
        }
    }

    private IEnumerator FlashbackCorForSprites(Sprite[] images, float dur)
    {
        sfxSource.Play();
        IsRunning = true;
        flashbackObj.SetActive(true);
        foreach (var image in images)
        {
            imageRef.sprite = image;
            yield return new WaitForSeconds(dur);
        }

        flashbackObj.SetActive(false);
        yield return new WaitForSeconds(5);
        IsRunning = false;
        sfxSource.Pause();
    }

    private IEnumerator FlashbackCor(FlashbackData[] images)
    {
        sfxSource.Play();
        IsRunning = true;
        flashbackObj.SetActive(true);
        foreach (var image in images)
        {
            imageRef.sprite = image.sprite;
            yield return new WaitForSeconds(image.duration);
            sfxSource.Play();
        }

        flashbackObj.SetActive(false);
        yield return new WaitForSeconds(5);
        IsRunning = false;
        sfxSource.Pause();
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