using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        } else
        {
            Debug.LogWarning("No MusicPlayer found. Start from Splash Screen");
        }
    }

    public void SetDefaults()
    {
        PlayerPrefsController.SetMasterVolume(defaultVolume);
        volumeSlider.value = defaultVolume;
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No MusicPlayer found. Start from Splash Screen");
        }
    }
}
