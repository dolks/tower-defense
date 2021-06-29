using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    int START_SCENE_INDEX = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadStartSceneAfter3Seconds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadStartSceneAfter3Seconds()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(START_SCENE_INDEX);
    }
}
