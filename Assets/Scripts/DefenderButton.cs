using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void OnMouseDown()
    {
        foreach (DefenderButton button in FindObjectsOfType<DefenderButton>())
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(65, 57, 57, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        if (defenderPrefab)
        {
            FindObjectOfType<MainPlayArea>().SetSelectedDefender(defenderPrefab);
        }
    }
}
