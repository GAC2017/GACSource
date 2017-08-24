using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBomb : MonoBehaviour {
    int Time = 2000;
    public GameObject child;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Lumberman"))
        {
            createChild();
            
            //other.gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("Soldier"))
        {
            //other.gameObject.SetActive(false);
        }
    }
    private void createChild()
    {
            Instantiate(child, transform.position + new Vector3(1, 0, 0) * 0.16F, transform.rotation);
            Instantiate(child, transform.position + new Vector3(1, 0, 0) * -0.16F, transform.rotation);
            Instantiate(child, transform.position + new Vector3(0, 1, 0) * 0.16F, transform.rotation);
            Instantiate(child, transform.position + new Vector3(0, 1, 0) * -0.16F, transform.rotation);
            Instantiate(child, transform.position + new Vector3(1, -1, 0) * 0.16F, transform.rotation);
            Instantiate(child, transform.position + new Vector3(1, -1, 0) * -0.16F, transform.rotation);
            Instantiate(child, transform.position + new Vector3(1, 1, 0) * 0.16F, transform.rotation);
            Instantiate(child, transform.position + new Vector3(1, 1, 0) * -0.16F, transform.rotation);
            gameObject.SetActive(false);
  
    }
}

