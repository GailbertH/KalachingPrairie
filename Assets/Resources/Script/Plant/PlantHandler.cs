using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHandler : MonoBehaviour 
{
	[SerializeField] List<PlantData> plantData;
	[SerializeField] List<PlantController> plantController;
	[SerializeField] Sprite soil;
	[SerializeField] Sprite deadPlant;

	public PlantController targetPlant;
	public Sprite GetEmptySoilForm
	{
		get{ return soil;}
	}
	public void AddPlant(PlantType type)
	{
		targetPlant.SetUpPlanting (plantData [(int)type]);
	}

	public void DayCycle()
	{
		for(int i = 0; i < plantController.Count; i++)
		{
			plantController [i].ReduceCountDown ();
			plantController [i].ChangePlantNeedState (PlantNeedState.WATER);
		}
	}
}
