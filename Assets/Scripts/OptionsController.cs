using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.5f;
    [SerializeField] float defaultDifficulty = 0.5f;
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVolume();
        UpdateDifficulty();
    }

    public void UpdateDifficulty()
    {
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
    }

    public void UpdateVolume()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
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

    public void SetDefaults()
    {
        PlayerPrefsController.SetMasterVolume(defaultVolume);
        PlayerPrefsController.SetDifficulty(defaultDifficulty);
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
