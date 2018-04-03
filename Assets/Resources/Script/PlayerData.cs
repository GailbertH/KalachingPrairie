using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
	public string playerName;
	public string characterType; //Boy or Girl
	public long cash;
	public long gold;
	public long dayMonthYear; //temporary
	public int time;
	public int daysElapsed;
	public int moonCycleCount;
	public Vector3 playerPosition;

	#region Inventory Region
	public int strawberrySeedCount;
	public int riceSeedCount;
	public int strawberryCount;
	public int riceCount;
	#endregion
}
public enum ItemEquip
{
	WATERING_CAN = 0,
	SEED = 1
}
