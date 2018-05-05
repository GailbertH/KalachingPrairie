using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstellationPopup : PopupBase 
{
	[SerializeField] private List<Sprite> conste;
	[SerializeField] private List<string> constelList;
	[SerializeField] private Image starContainer;
	[SerializeField] private Text consteName;

	public void SetConMap()
	{
		if (GameManager.Instance == null)
			return;

		if (GameManager.Instance.MonthCounter > conste.Count)
			return;

		starContainer.sprite = conste[GameManager.Instance.MonthCounter];

		if (GameManager.Instance.MonthCounter > constelList.Count) 
		{
			consteName.text = "";
			return;
		}
		consteName.text = constelList [GameManager.Instance.MonthCounter];
	}

	public override void ButtonClose()
	{
		GameManager.Instance.GameControls.ScreenActivate (true);
		Invoke ("Hide", 0.5f);
	}
	public override void Hide()
	{
		GameManager.Instance.GameControls.ContinueTime ();
		GameManager.Instance.GameControls.ScreenActivate (false);
		this.gameObject.SetActive (false);
	}
}

