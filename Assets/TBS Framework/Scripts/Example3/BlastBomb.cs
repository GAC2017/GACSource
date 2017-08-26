using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Too complicated: not used for now
public class BlastBomb : Trigger {

    public GameObject child;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainCharacter"))
        {
            createChild();
            
            //other.gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("Soldier"))
        {
            //other.gameObject.SetActive(false);
        }
    }

	public override void ApplyEffectOnActivation (Unit target)
	{
		//Don't do anything here because the "spawning" effect is enough.
		//Or maybe play a sound or something...?
	}

	/// <summary>
	/// TODO: need to add these new children to the list of Triggers in CellGrid.
	/// And then remove them afterwards. This is why it's hard :). 
	/// </summary>
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

