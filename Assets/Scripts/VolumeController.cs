using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    void Update()
    {
        AudioListener.volume = GetComponent<Slider>().value;
    }
}
