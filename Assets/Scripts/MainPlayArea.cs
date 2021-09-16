using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayArea : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown()
    {
        Vector2 mousePos = getMousePos();
        Instantiate(defender, mousePos, Quaternion.identity);
    }

    private Vector2 getMousePos()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
