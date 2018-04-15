using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour 
{
	[SerializeField] PlantHandler handler;
	[SerializeField] SpriteRenderer spriteRender;
	//int counter = 0;
	PlantData pData;

	private bool isEmpty = true;

	public bool GetIsEmpty
	{
		get { return isEmpty;}
	}
		
	void OnMouseDown()
	{
		if (GameManager.Instance == null && GameManager.Instance.PlayerHandler == null && handler == null)
			return;

		handler.targetPlant = this;

		if (pData != null && pData.plantNeed == PlantNeedState.HARVEST) 
		{
			handler.RemovePlant ();
		}
		else if (GameManager.Instance.PlayerHandler.GetItemEquip == ItemEquip.SEED && isEmpty) 
		{
			handler.AddPlant (GameManager.Instance.PlayerHandler.GetSeedType);
			pData.plantNeed = PlantNeedState.WATER;
		} 
		else if (GameManager.Instance.PlayerHandler.GetItemEquip == ItemEquip.WATERING_CAN 
			&& !isEmpty && pData.plantNeed == PlantNeedState.WATER)
		{
			pData.plantNeed = PlantNeedState.NONE;
		}
	}

	public void ChangePlantNeedState(PlantNeedState state)
	{
		if(!isEmpty)
			pData.plantNeed = state;
	}

	public void ReduceCountDown()
	{
		if (!isEmpty && pData != null && pData.countDown >= 0) 
		{
			pData.countDown -= 1;
			UpdatePlant ();
		}
	}

	public void SetUpPlanting(PlantData data)
	{
		if (data != null) 
		{
			pData = data.Copy ();
			isEmpty = false;
			spriteRender.sprite	= pData.spriteForms [0];
		}
		else
		{
			isEmpty = true;
			pData = null;
		}
		
		UpdatePlant ();
	}

	public void UpdatePlant()
	{
		if (pData == null) 
		{
			spriteRender.sprite = handler.GetEmptySoilForm;
			isEmpty = true;
			return;
		}

		int tracker = pData.daysRequired - pData.countDown;
		tracker = tracker / 2;
		if (tracker < pData.spriteForms.Length && !isEmpty && pData.spriteForms[tracker] != null) 
		{
			spriteRender.sprite	= pData.spriteForms [tracker];
			if (tracker == pData.spriteForms.Length - 1 || pData.countDown <= 0)
				ChangePlantNeedState (PlantNeedState.HARVEST);
			else
				ChangePlantNeedState (PlantNeedState.WATER);
		} 
		else if(isEmpty)
		{
			spriteRender.sprite = handler.GetEmptySoilForm;
			isEmpty = true;
		}
	}
}
