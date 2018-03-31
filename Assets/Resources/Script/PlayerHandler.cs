using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHandler : MonoBehaviour {

	[SerializeField] GameObject Player;
	private PlayerData playerData;
	private ItemEquip equipedItem = ItemEquip.WATERING_CAN;
	private PlantType seedType = PlantType.STRAWBERRY;
	private int EquipItemTracker = 0;
	private int SeedEquipTracker = 0;
	// Update is called once per frame
	public ItemEquip GetItemEquip
	{
		get{ return equipedItem;}
	}
	public PlantType GetSeedType
	{
		get{ return seedType;}
	}

	public void ChangeItemEquip()
	{
		if (EquipItemTracker == (int)ItemEquip.SEED) 
		{
			if (SeedEquipTracker == (int)PlantType.RICE) 
			{
				EquipItemTracker = 0;
				SeedEquipTracker = 0;
				seedType = PlantType.STRAWBERRY;
				equipedItem = ItemEquip.WATERING_CAN;
				return;
			} 
			else 
			{
				SeedEquipTracker += 1;
				seedType = (PlantType)SeedEquipTracker;
				return;
			}
		}
		EquipItemTracker += 1;
		equipedItem = (ItemEquip)EquipItemTracker;
	}

	void FixedUpdate () 
	{
		if (GameManager.Instance == null )
			return;

		if (GameManager.Instance.GameControls == null)
			return;

		Vector2 newPos = GameManager.Instance.GameControls.GetTouchInput;
		if (GameManager.Instance.GetAreaMode == AreaMode.TOWN)
			newPos.y = this.transform.position.y;
		
		Vector2 curPos = new Vector2 (this.transform.position.x, this.transform.position.y);
		//Player.transform.localPosition = Vector2.MoveTowards(curPos, newPos, 0.05f);
		Player.GetComponent<Rigidbody2D> ().MovePosition (Vector2.MoveTowards(curPos, newPos, 0.05f));
	}
}
