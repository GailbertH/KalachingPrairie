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

	void Start()
	{
		Invoke ("DelayTurnOn", 0.5f);
	}

	private void DelayTurnOn()
	{
		if(plantController != null)
			for (int i = 0; i < plantController.Count; i++)
				plantController [i].gameObject.SetActive (true);
	}

	public Sprite GetEmptySoilForm
	{
		get{ return soil;}
	}
	public void AddPlant(PlantType type)
	{
		targetPlant.SetUpPlanting (plantData [(int)type]);
	}
	public void RemovePlant()
	{
		targetPlant.SetUpPlanting (null);
	}

	public void DayCycle()
	{
		for(int i = 0; i < plantController.Count; i++)
		{
			plantController [i].ReduceCountDown ();
		}
	}
}
