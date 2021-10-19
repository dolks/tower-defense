using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 30;
    Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        livesText.text = lives.ToString();
    }

    public void AddLives(int amount)
    {
        lives += amount;
        livesText.text = lives.ToString();
    }

    public void SubtractLives(int amount)
    {
        lives -= amount;
        if (lives < 0)
        {
            lives = 0;
            SceneManager.LoadScene("Lose Screen");
        }
        livesText.text = lives.ToString();
    }

    public int GetCurrentLivesInt()
    {
        return lives;
    }
}
