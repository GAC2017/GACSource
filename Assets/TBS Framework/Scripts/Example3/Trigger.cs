using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A class modelled after Unit to handle placable triggers
//To be spawned from CustomUnitGenerator.
public abstract class Trigger : MonoBehaviour, IAttackCapable
{
	public Trigger ()
	{
	}

	public virtual void Initialize()
	{
		IsActive = true;
	}

	public bool IsActive { get; set; }

	/// <summary>
	/// Cell that the unit is currently occupying.
	/// </summary>
	public Cell Cell { get; set; }

	//The range of the trigger - triggers can be come activated a distance away from a target!
	private int _effectRange = 0;
	public int EffectRange 
	{ 
		get { return _effectRange; }
		set { _effectRange = value; }
	}

	public int Damage { get; set; }

	/// <summary>
	/// Applies the effect on activation.
	/// </summary>
	/// <returns><c>true</c>, if target is destroyed, <c>false</c> otherwise.</returns>
	/// <param name="target">Target unit</param>
	public abstract void ApplyEffectOnActivation(Unit target);
}


