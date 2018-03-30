using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PlantType
{
	STRAWBERRY = 0,
	RICE = 1
}

public enum PlantNeedState
{
	SOIL = 0,
	WATER = 1,
	WEED = 2,
	HARVEST = 4,
	REMOVING = 5
}

[Serializable]
public class PlantData 
{
	public int ID;
	public PlantType plantType;
	public PlantNeedState plantNeed;
	public int moonCycle;
	public long cash;
	public long countDown;
	public Sprite currentSpriteForm;
	public Sprite[] spriteForms;
}
