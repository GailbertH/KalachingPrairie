using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum ToggleState
{
	SHOW = 0,
	HIDE = 1
}

public class KalachingGameControls : MonoBehaviour 
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private Text timeLabel;
	[SerializeField] private RectTransform menu;
	[SerializeField] private MovementTouchController movementTouchController;
	[SerializeField] private List<PopupBase> shopPopup;
	[SerializeField] private RectTransform toggleButton;
	[SerializeField] private GameObject screenBlack;
	[SerializeField] private List<GameObject> EquipmentList;

	private int time = 14400;
	private const int MIN_TIME = 0;
	private const int MAX_TIME = 86400;
	private Coroutine timeRoutineHolder = null;
	private ToggleState toggleState;
	private static KalachingGameControls instance;
	public static KalachingGameControls Instance { get { return instance; } }
	public float GetControlHorizontal{ get {return movementTouchController.Horizontal ();} }
	public float GetControlVertical{ get {return movementTouchController.Vertical ();} }
	public Vector2 GetTouchInput{ get { return movementTouchController.TouchPosition (); } }

	void Awake()
	{
		instance = this;
		this.gameObject.SetActive (false);
	}
		
	public void ShowGameControls()
	{
		this.gameObject.SetActive (true);
		toggleState = ToggleState.HIDE;
		Vector3 rectPost = menu.anchoredPosition3D;
		rectPost = new Vector3 (860f, 0f, 0f);
		menu.anchoredPosition3D = rectPost;

		time = PlayerPrefs.GetInt ("GAME_TIME", time);
		timeLabel.text = TimeConverter (time);
		timeRoutineHolder = StartCoroutine (TimeRoutine ());
	}
	void OnDestroy()
	{
		PlayerPrefs.SetInt ("GAME_TIME", time);
		StopCoroutine (timeRoutineHolder);
		timeRoutineHolder = null;
	}

	public void NewDay()
	{
		time = 0;
	}

	private IEnumerator TimeRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds (1);
			if (time <= MAX_TIME)
			{
				time += 30;
			}
			else 
			{
				time = 0;
			}
			timeLabel.text = TimeConverter (time);
			yield return new WaitForEndOfFrame ();
		}
	}

	private string TimeConverter(int timeToConvert)
	{
		int hour = 0;
		int min = 0;
		//int sec = 0;
		string AMPM = "";

		hour = timeToConvert / 3600;
		hour = hour == 0 ? 12 : hour;
		AMPM = hour > 12 ? "PM" : "AM";
		hour = hour > 12 ? hour - 12 : hour;
		min = (timeToConvert % 3600) / 60;
		//sec = (((timeToConvert % 3600) % 60));
		return (hour.ToString ("00:") + min.ToString ("00:") + " " + AMPM);
	}

	public void ScreenActivate(bool show)
	{
		screenBlack.SetActive (show);
	}

	public void MakePopup(string msg, Action yes, Action no = null)
	{
		((Popup_Confirmation)shopPopup[1]).SetupPopup (msg, yes, no);
		shopPopup [1].Show ();
	}

	#region Button
	public void Home()
	{
		if(GameManager.Instance.GetAreaMode == AreaMode.FARM)
			LoadingManager.Instance.SetSceneToUnload (SceneNames.GAME_UI + "," + SceneNames.GAME_SCENE);
		else
			LoadingManager.Instance.SetSceneToUnload (SceneNames.GAME_UI + "," + SceneNames.TOWN_SCENE);
		LoadingManager.Instance.SetSceneToLoad (SceneNames.MAIN_MENU);
		LoadingManager.Instance.LoadGameScene ();
	}

	public void Equipment()
	{
		if (GameManager.Instance == null)
			return;

		if (GameManager.Instance.PlayerHandler == null)
			return;

		GameManager.Instance.PlayerHandler.ChangeItemEquip ();

		int item = 0;
		if (GameManager.Instance.PlayerHandler.GetItemEquip == ItemEquip.WATERING_CAN) 
			item = (int)GameManager.Instance.PlayerHandler.GetItemEquip;
		
		else if (GameManager.Instance.PlayerHandler.GetItemEquip == ItemEquip.SEED)
			item = (int)(GameManager.Instance.PlayerHandler.GetItemEquip) + (int)(GameManager.Instance.PlayerHandler.GetSeedType);
		
		if(item < EquipmentList.Count)
			ShowItem(item);
	}

	private void ShowItem(int targetIndex)
	{
		for (int i = 0; i < EquipmentList.Count; i++)
		{
			EquipmentList [i].SetActive (i == targetIndex);
		}
	}

	public void ToggleMenu()
	{
		Vector3 rectPost = menu.anchoredPosition3D;
		if (toggleState == ToggleState.HIDE) 
		{
			toggleButton.Rotate (0, 0, 180f);
			toggleState = ToggleState.SHOW;
			rectPost = Vector3.zero;
		} 
		else 
		{
			toggleButton.Rotate (0, 0, 180f);
			toggleState = ToggleState.HIDE;
			rectPost = new Vector3 (860f, 0f, 0f);
		}
		menu.anchoredPosition3D = rectPost;
	}

	public void Journal()
	{
		shopPopup[2].Show ();
	}
	public void Inventory()
	{

	}

	public void Map()
	{
		if (GameManager.Instance == null)
			return;
		
		if(GameManager.Instance.GetAreaMode == AreaMode.FARM)
			((Popup_Confirmation)shopPopup[1]).SetupPopup ("Do you want to go to Town? ", GoToTown, null);
		else
			((Popup_Confirmation)shopPopup[1]).SetupPopup ("Do you want to go back to your Farm?", GoToFarm, null);

		shopPopup [1].Show ();
	}

	public void GoToTown()
	{
		ScreenActivate (true);
		LoadingManager.Instance.SetSceneToUnload (SceneNames.GAME_SCENE);
		LoadingManager.Instance.SetSceneToLoad (SceneNames.TOWN_SCENE);
		LoadingManager.Instance.LoadGameScene ();
	}
	public void GoToFarm()
	{
		ScreenActivate (true);
		LoadingManager.Instance.SetSceneToUnload (SceneNames.TOWN_SCENE);
		LoadingManager.Instance.SetSceneToLoad (SceneNames.GAME_SCENE);
		LoadingManager.Instance.LoadGameScene ();
	}

	public void Shop()
	{
		shopPopup[0].Show ();
	}
	public void Settings()
	{

	}
	#endregion
}
