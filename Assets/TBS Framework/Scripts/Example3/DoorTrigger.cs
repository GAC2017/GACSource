using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : Trigger
{
	public GameObject DoorCell;
	public Sprite NoDoorSprite;

	public override void ApplyEffectOnActivation (Unit target)
	{
		MySquare doorTile = DoorCell.GetComponent<MySquare> ();
		doorTile.IsTaken = false;
		SpriteRenderer renderer = DoorCell.GetComponent<SpriteRenderer> ();
		renderer.sprite = NoDoorSprite;
		this.IsActive = false;
		this.gameObject.SetActive (false);
	}
}
