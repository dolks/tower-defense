using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    int enemiesSpawned = 0;
    int enemiesKilledSoFar = 0;
    bool levelFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] AudioClip winSFX;
    [SerializeField] float timeBeforeNextLevel = 5;

    private void Start()
    {
        Time.timeScale = 1;
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    void Update()
    {
        if (levelFinished || FindObjectOfType<GameTimer>() == null) { return; }
        if (enemiesKilledSoFar == enemiesSpawned
            && FindObjectOfType<GameTimer>().IsFinished())
        {
            levelFinished = true;
            winLabel.SetActive(true);
            StartCoroutine(HandleWinCondition());
        }
    }

    public void AddEnemyKill() { enemiesKilledSoFar++; }

    public void AddEnemySpawn() { enemiesSpawned++; }

    public void StopSpawners()
    {
        foreach(AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.StopSpawing();
        }
    }

    IEnumerator HandleWinCondition()
    {
        AudioSource.PlayClipAtPoint(winSFX, transform.position, 50);
        yield return new WaitForSeconds(timeBeforeNextLevel);
        SceneManager.LoadScene("Level 2");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Lose()
    {
        loseLabel.SetActive(true);
        FindObjectOfType<GameTimer>().GetComponent<Slider>().value = 0;
        Time.timeScale = 0;
    }
}
