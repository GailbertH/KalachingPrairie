using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPopup : PopupBase
{
	[SerializeField] List<GameObject> pages;
	private int pageTracker = 0;

	public override void Setup()
	{
		if (pages.Count > 0) {
			for (int i = 0; i < pages.Count; i++) {
				pages [i].SetActive (false);
			}
			pages [0].SetActive (true);
			pageTracker = 0;
		} else
			Hide ();
	}
	public void ButtonFlip()
	{
		pageTracker += 1;
		if (pages.Count <= pageTracker) 
		{
			pageTracker = 0;	
		}
		for (int i = 0; i < pages.Count; i++) 
		{
			pages [i].SetActive (false);
		}
		pages [pageTracker].SetActive (true);
	}
}
