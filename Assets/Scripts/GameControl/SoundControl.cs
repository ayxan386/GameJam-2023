using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string sfxVar;


    private void Start()
    {
        var slider = GetComponent<Slider>();
        audioMixer.GetFloat(sfxVar, out float initialVal);
        slider.value = Mathf.Pow(2, initialVal);
    }

    public void ValueChanged(float val)
    {
        audioMixer.SetFloat(sfxVar, Mathf.Log(val));
    }
}