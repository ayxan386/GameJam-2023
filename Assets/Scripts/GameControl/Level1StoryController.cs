using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class Level1StoryController : MonoBehaviour
{
    [Description(
        "0 - initial\n 1 - dialog dur. \n 2 - noise dur. \n 3 - remember dur \n 4 - flashback delay \n 5 - flashback dur 6 - last dialog")]
    [SerializeField]
    private float[] delays;

    [SerializeField] private AudioSource startNoise;
    [SerializeField] private string[] dialogs;
    [SerializeField] private AudioSource musicSource;

    private int currentDelay;
    private int currentDialog;

    IEnumerator Start()
    {
        GlobalStateManager.CanMove = false;
        musicSource.Pause();
        yield return new WaitForSeconds(delays[currentDelay++]);
        //Noise and what happened
        startNoise.Play();
        DialogController.Instance.DisplayDialog(dialogs[currentDialog++], delays[currentDelay++]);
        yield return new WaitForSeconds(delays[currentDelay++]);
        // I think I remember
        DialogController.Instance.DisplayDialog(dialogs[currentDialog++], delays[currentDelay++]);
        yield return new WaitForSeconds(delays[currentDelay++]);
        startNoise.Pause();
        FlashbackController.Instance.PlayFlashBack("beginning");
        yield return new WaitForSeconds(delays[currentDelay++]);
        // I wonder
        DialogController.Instance.DisplayDialog(dialogs[currentDialog++], delays[currentDelay++]);
        yield return new WaitForSeconds(delays[currentDelay++]);
        // Let's look for clues
        DialogController.Instance.DisplayDialog(dialogs[currentDialog++], delays[currentDelay++]);
        musicSource.Play();
        GlobalStateManager.CanMove = true;
    }
}