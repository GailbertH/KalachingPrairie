using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBase : MonoBehaviour 
{
	public void Show()
	{
		this.gameObject.SetActive (true);
	}
	public void ButtonClose()
	{
		this.Hide ();
	}
	public void Hide()
	{
		this.gameObject.SetActive (false);
	}
}
