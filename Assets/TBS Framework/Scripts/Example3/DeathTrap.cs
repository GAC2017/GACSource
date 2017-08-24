using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrap : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag ("Lumberman")) 
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Soldier"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
