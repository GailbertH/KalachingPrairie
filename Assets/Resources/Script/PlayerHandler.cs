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
		Vector2 newPos = GameManager.Instance.GameControls.GetTouchInput;
		Vector2 curPos = new Vector2 (this.transform.position.x, this.transform.position.y);
		Player.transform.localPosition = Vector2.MoveTowards(curPos, newPos, 0.05f);
			
	}
}
