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
	REMOVING = 5,
	NONE = 6
}

public enum CropType
{
	NONE = 0,
	FRUITING = 1,
	ROOTING = 2
}

[Serializable]
public class PlantData 
{
	public int ID;
	public PlantType plantType;
	public PlantNeedState plantNeed;
	public CropType cropType;
	public int daysRequired;
	public int countDown;
	public long cash;
	public Sprite currentSpriteForm;
	public Sprite[] spriteForms;

	public PlantData Copy()
	{
		PlantData data = new PlantData ();
		data.ID = ID;
		data.plantType = plantType;
		data.plantNeed = plantNeed;
		data.cropType = cropType;
		data.daysRequired = daysRequired;
		data.countDown = countDown;
		data.cash = cash;
		data.currentSpriteForm = currentSpriteForm;
		data.spriteForms = spriteForms;
		return data;
	}
}
