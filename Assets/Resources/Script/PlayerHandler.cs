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
		if (GameManager.Instance == null)
			return;

		Vector2 newPos = GameManager.Instance.GameControls.GetTouchInput;
		if (GameManager.Instance.GetAreaMode == AreaMode.TOWN)
			newPos.y = this.transform.position.y;
		
		Vector2 curPos = new Vector2 (this.transform.position.x, this.transform.position.y);
		Player.transform.localPosition = Vector2.MoveTowards(curPos, newPos, 0.05f);
			
	}
}
