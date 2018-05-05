using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (GameManager.Instance == null)
			return;
		if (GameManager.Instance.GameControls == null)
			return;

		GameManager.Instance.GameControls.Map ();
	}
}
