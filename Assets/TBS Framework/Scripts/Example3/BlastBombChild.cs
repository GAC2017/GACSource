using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBombChild : MonoBehaviour {
    int Time = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Lumberman"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Soldier"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        Time = Time - 1;
        if(Time == 0)
        {
           
            gameObject.SetActive(false);
      
        }
            

    }
}