using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("The time for the level in seconds")]
    [SerializeField] float levelTime = 0.5f;
    bool isFinished;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        if (Time.timeSinceLevelLoad >= levelTime)
        {
            FindObjectOfType<LevelController>().StopSpawners();
            isFinished = true;
        }
    }

    public bool IsFinished() { return isFinished; }
}
