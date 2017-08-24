using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowGoo : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Lumberman"))
        {
            //SlowGoo speed = other.gameObject.GetComponent<MovementPoints>();
            //speed();
        }
        if (other.gameObject.CompareTag("Soldier"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
