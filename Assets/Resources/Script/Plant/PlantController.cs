using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour 
{
	[SerializeField] PlantHandler handler;
	[SerializeField] SpriteRenderer spriteRender;
	[SerializeField] GameObject waterIcon;

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

		//Debug.Log (Vector3.Distance (GameManager.Instance.PlayerHandler.transform.position, this.transform.position));
		if (Vector3.Distance (GameManager.Instance.PlayerHandler.transform.position, this.transform.position) > 4.5f)
			return;

		handler.targetPlant = this;

		if (pData != null && pData.plantNeed == PlantNeedState.HARVEST) 
		{
			handler.RemovePlant ();
		}
		else if (GameManager.Instance.PlayerHandler.GetItemEquip == ItemEquip.SEED && isEmpty) 
		{
			GameManager.Instance.PlayerHandler.DontMove ();
			handler.AddPlant (GameManager.Instance.PlayerHandler.GetSeedType);
			ChangePlantNeedState (PlantNeedState.WATER);
		} 
		else if (GameManager.Instance.PlayerHandler.GetItemEquip == ItemEquip.WATERING_CAN 
			&& !isEmpty && pData.plantNeed == PlantNeedState.WATER)
		{
			GameManager.Instance.PlayerHandler.WateringAction ();
			ChangePlantNeedState (PlantNeedState.NONE);
		}
	}

	public void ChangePlantNeedState(PlantNeedState state)
	{
		if(!isEmpty)
			pData.plantNeed = state;

		if (pData.plantType == PlantType.RICE && pData.plantNeed == PlantNeedState.WATER)
			pData.plantNeed = PlantNeedState.NONE;

		if (waterIcon == null)
			return;
		
		if (pData.plantNeed == PlantNeedState.WATER && pData.plantType != PlantType.RICE)
			waterIcon.SetActive (true);
		else
			waterIcon.SetActive (false);
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
			else if(pData.plantType != PlantType.RICE)
				ChangePlantNeedState (PlantNeedState.WATER);
		} 
		else if(isEmpty)
		{
			spriteRender.sprite = handler.GetEmptySoilForm;
			isEmpty = true;
		}
	}
}
