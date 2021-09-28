using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayArea : MonoBehaviour
{
    [SerializeField] Defender defender;

    private void OnMouseDown()
    {
        Vector2 mousePos = getMousePos();
        Instantiate(defender, mousePos, Quaternion.identity);
    }

    private Vector2 SnapToWorldPos(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private Vector2 getMousePos()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        return SnapToWorldPos(Camera.main.ScreenToWorldPoint(mousePos));
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }
}
