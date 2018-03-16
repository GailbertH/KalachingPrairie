using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {

	[SerializeField] GameObject Player;
	private float vertical = 0;
	private float horizontal = 0;

	// Update is called once per frame
	void FixedUpdate () 
	{
		vertical = GameManager.Instance.GameControls.GetControlVertical;
		horizontal = GameManager.Instance.GameControls.GetControlHorizontal;
		Player.transform.localPosition = new Vector3 (Player.transform.localPosition.x + horizontal * 0.1f, Player.transform.localPosition.y + vertical* 0.1f, 0);
	}
}
