using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;
    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        starText.text = stars.ToString();
    }

    public void SubtractStars(int amount)
    {
        stars -= amount;
        if (stars < 0)
        {
            stars = 0;
        }
        starText.text = stars.ToString();
    }

    public int GetCurrentStarsInt()
    {
        return stars;
    }
}
