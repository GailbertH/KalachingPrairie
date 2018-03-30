using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_ChangeLoc : PopupBase 
{
	public void YesButton()
	{
		if(GameManager.Instance.GetAreaMode == AreaMode.TOWN)
			KalachingGameControls.Instance.GoToFarm ();
		else
			KalachingGameControls.Instance.GoToTown ();

		ButtonClose ();
	}
	public void NoButton()
	{
		ButtonClose ();
	}
}
