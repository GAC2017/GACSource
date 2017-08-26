using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrap : Trigger {

    private void OnTriggerEnter2D(Collider2D other)
    {
//        if(other.gameObject.CompareTag ("Lumberman")) 
//        {
//            other.gameObject.SetActive(false);
//        }
//        if (other.gameObject.CompareTag("Soldier"))
//        {
//            
//        }

		//Simply hide the Sprite for now, later: animation?
		other.gameObject.SetActive(false);
    }

	//Attempting to insta-kill, vastly exceeding defence factor
	public override void ApplyEffectOnActivation (Unit target)
	{
		if (this.IsActive) {
			if (target.PlayerNumber == 0) {
				target.GetDamaged (this, target.HitPoints * 1000);
			} else { //Freeze enemies - don't kill because there is bug that will crash Unity if all enemies are killed.
				target.Freeze (3);
				this.IsActive = false;//remove the trap
				this.gameObject.SetActive(false);
			}
		}
	}
}
