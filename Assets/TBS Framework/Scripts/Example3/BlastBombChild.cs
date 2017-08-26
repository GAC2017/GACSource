using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Too complicated: not used for now
public class BlastBombChild : Trigger {
    private int _time = 20000;

    private void OnTriggerEnter2D(Collider2D other)
    {
		//other.gameObject.
    }

    private void LateUpdate()
    {
		_time = _time - 1;
		if(_time == 0)
        {
           
            gameObject.SetActive(false);
      
        }
    }

	//Attempting to insta-kill, vastly exceeding defence factor
	public override void ApplyEffectOnActivation (Unit target)
	{
		target.GetDamaged (this, target.HitPoints * 1000);
	}
}