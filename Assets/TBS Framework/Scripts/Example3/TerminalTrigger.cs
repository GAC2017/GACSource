using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalTrigger : Trigger
{
	//Configurable by Unity
	public NextGuiController control;
	public string DestinationSceneName;

	public override void ApplyEffectOnActivation (Unit target)
	{
		//Trigger scene changed when touched by a human character
		if (target.PlayerNumber == 0)
		{
			control.NextLevel (DestinationSceneName);
		}
	}
		
//	private void OnTriggerEnter2D(Collider2D other)
//	{
//		
//	}
}

