using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KalachingGameControls : MonoBehaviour 
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private Text timeLabel;

	private int time = 14400;
	private const int MIN_TIME = 0;
	private const int MAX_TIME = 86400;

	private static KalachingGameControls instance;
	public static KalachingGameControls Instance { get { return instance; } }
	private Coroutine timeRoutineHolder = null;
	void Awake()
	{
		instance = this;
	}

	void Start()
	{
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

	private IEnumerator TimeRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds (1);
			if (time <= MAX_TIME)
			{
				time += 12;
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
		int sec = 0;
		string AMPM = "";

		hour = timeToConvert / 3600;
		hour = hour == 0 ? 12 : hour;
		AMPM = hour > 12 ? "PM" : "AM";
		hour = hour > 12 ? hour - 12 : hour;
		min = (timeToConvert % 3600) / 60;
		sec = (((timeToConvert % 3600) % 60));
		return (hour.ToString ("00:") + min.ToString ("00:") + sec.ToString ("00") + " " + AMPM);
	}

	public void Home()
	{
		LoadingManager.Instance.SetSceneToUnload (SceneNames.GAME_UI + "," + SceneNames.GAME_SCENE);
		LoadingManager.Instance.SetSceneToLoad (SceneNames.MAIN_MENU);
		LoadingManager.Instance.LoadGameScene ();
	}
	public void Journal()
	{

	}
	public void Inventory()
	{

	}
	public void Map()
	{

	}
	public void Shop()
	{

	}
	public void Settings()
	{

	}
}
