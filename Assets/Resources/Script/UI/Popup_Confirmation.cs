using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Popup_Confirmation : PopupBase 
{
	[SerializeField] Text message;
	Action yesButton = null;
	Action noButton = null;

	public void SetupPopup(string text, Action yes, Action no)
	{
		message.text = text;
		yesButton = yes;
		noButton = no;
	}

	public void YesButton()
	{
		if(yesButton != null)
			yesButton.Invoke ();
		
		ButtonClose ();
	}
	public void NoButton()
	{
		if(noButton != null)
			noButton.Invoke ();
		
		ButtonClose ();
	}
}
