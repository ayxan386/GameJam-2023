using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBackLoop : MonoBehaviour
{
    [SerializeField] private Image imageRef;
    [SerializeField] private string folderName;
    [SerializeField] private float dur = 1.0f / 80;

    private void Start()
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
        // while (true)
        {
            int dir = 1;
            for (int i = 0; i < images.Length; i += dir)
            {
                if (i == images.Length - 1) dir = -1;
                if (i == 0) dir = 1;
                imageRef.sprite = images[i];
                yield return new WaitForSeconds(dur);
            }
        }
    }
}