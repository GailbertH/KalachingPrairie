using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBase : MonoBehaviour 
{
	public virtual void Show()
	{
		this.gameObject.SetActive (true);
		Setup ();
	}
	public virtual void Setup()
	{
		
	}
	public virtual void ButtonClose()
	{
		this.Hide ();
	}
	public virtual void Hide()
	{
		this.gameObject.SetActive (false);
	}
}
