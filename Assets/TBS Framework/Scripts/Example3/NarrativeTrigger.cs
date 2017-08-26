using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeTrigger : Trigger
{
	public GameObject NarratorPanel;
	private GameObject _narratorPanel;
	public Canvas Canvas;
	public bool RunOnlyOnce;

	//Multiple images here to provide for more flexibility
	public Sprite NarrativeImage1;
	public Sprite NarrativeImage2;
	public Sprite NarrativeImage3;
	public Sprite NarrativeImage4;
	public Sprite NarrativeImage5;

	private List<Sprite> _images;
	private int _currentImageIndex = 0;

	public override void Initialize()
	{
		base.Initialize ();

		_images = new List<Sprite> ();

		if (NarrativeImage1 != null) {
			_images.Add (NarrativeImage1);
		} 
		if (NarrativeImage2 != null) {
			_images.Add (NarrativeImage2);
		}
		if (NarrativeImage3 != null) {
			_images.Add (NarrativeImage3);
		} 
		if (NarrativeImage4 != null) {
			_images.Add (NarrativeImage4);
		}
		if (NarrativeImage5 != null) {
			_images.Add (NarrativeImage5);
		}
	}

	public override void ApplyEffectOnActivation (Unit target)
	{
		if (!IsActive)
			return;
		
		if (target.PlayerNumber == 0) {
			_narratorPanel = Instantiate (NarratorPanel);

			//TODO: there is a strange tranparency issue with the sprite, but it looks kinda good :).
			_narratorPanel.GetComponent<Image> ().sprite = _images[_currentImageIndex];

			//_gameOverPanel.transform.Find("InfoText").GetComponent<Text>().text = "Player " + ((sender as CellGrid).CurrentPlayerNumber + 1) + "\nwins!";

			//_narratorPanel.transform.Find ("InfoText").GetComponent<Text> ().text = "Is this the end? Is this the end? Is this the end? Is this the end? Is this the end? Is this the end? Is this the end?";

			Button dismissBtn = _narratorPanel.transform.Find ("DismissButton").GetComponent<Button> ();
			if (_images.Count > 1) {
				SetDismissButtonText ("Next");
			}

			dismissBtn.onClick.AddListener (DismissPanel);

			_narratorPanel.GetComponent<RectTransform> ().SetParent (Canvas.GetComponent<RectTransform> (), false);
		}
	}

	private void SetDismissButtonText(string newText)
	{
		Button dismissBtn = _narratorPanel.transform.Find ("DismissButton").GetComponent<Button> ();
		Text txt = dismissBtn.transform.Find("Text").GetComponent<Text>();
		txt.text = newText;
	}

	public void DismissPanel()
	{	
		if (_currentImageIndex == _images.Count - 1) {
			Destroy (_narratorPanel);
			_currentImageIndex = 0;

			if (RunOnlyOnce) 
			{
				this.IsActive = false;
				this.gameObject.SetActive(false);
			}
		} 
		else 
		{
			if (_currentImageIndex == _images.Count - 2) 
			{
				SetDismissButtonText ("Dismiss");
			}
			_currentImageIndex++;
			_narratorPanel.GetComponent<Image> ().sprite = _images[_currentImageIndex];
		}

	}
}

