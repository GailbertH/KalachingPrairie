using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other) 
	{
		GameManager.Instance.GameControls.MakePopup("Do you want to go to bed?", Sleep);
	}

	public void Sleep()
	{
		GameManager.Instance.GameControls.ScreenActivate (true);
		Invoke ("PlayerWakeUp", 1f);
	}

	private void PlayerWakeUp()
	{
		GameManager.Instance.GameControls.ScreenActivate (false);
		GameManager.Instance.PlayerGoToSleep ();
	}
}
