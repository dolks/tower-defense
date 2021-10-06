using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayArea : MonoBehaviour
{
    [SerializeField] Defender defender;

    private void OnMouseDown()
    {
        Vector2 worldPos = getWorldPos();
        if (defender)
        {
            AttemptToPlaceDefenderAt(worldPos);

        }
    }

    private Vector2 SnapToWorldPos(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private Vector2 getWorldPos()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        return SnapToWorldPos(Camera.main.ScreenToWorldPoint(mousePos));
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    public void AttemptToPlaceDefenderAt(Vector2 worldPos)
    {
        StarScript starScript = FindObjectOfType<StarScript>();
        int starCost = defender.GetStarCost();
        if (starScript.GetCurrentStarsInt() >= starCost)
        {
            Instantiate(defender, worldPos, Quaternion.identity);
            starScript.SubtractStars(starCost);
        }
    }
}
