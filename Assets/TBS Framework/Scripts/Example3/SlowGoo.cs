using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowGoo : Trigger {
    
    private void OnTriggerEnter2D(Collider2D other)
    {
//        if (other.gameObject.CompareTag("Lumberman"))
//        {
//            //SlowGoo speed = other.gameObject.GetComponent<MovementPoints>();
//            //speed();
//        }
//        if (other.gameObject.CompareTag("Soldier"))
//        {
//            other.gameObject.SetActive(false);
//        }
	}

	public override void ApplyEffectOnActivation (Unit target)
	{
		//Doesn't do anything at the moment because characters can only move one square at the moment 26/8/2017 - MrN.
	}
}
