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
	public Vector3 playerPosition;

	#region Inventory Region
	public int strawberrySeedCount;
	public int riceSeedCount;
	public int strawberryCount;
	public int riceCount;
	#endregion
}
