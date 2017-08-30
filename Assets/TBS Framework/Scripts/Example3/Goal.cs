using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public NextGuiController control;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Lumberman"))
        {
            control.NextLevel();
            Debug.Log("go");
        }
        else if (other.gameObject.CompareTag("Soldier"))
        {
            control.NextLevel();
            Debug.Log("go");
        }
    }
}
