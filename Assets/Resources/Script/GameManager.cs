using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kalaching.Game;

public enum AreaMode
{
	FARM = 0,
	TOWN = 1
}

public enum Month
{
	JAN = 1,
	FEB = 2,
	MAR = 3,
	APR = 4,
	MAY = 5,
	JUN = 6,
	JUL = 7,
	AUG = 8,
	SEP = 9,
	OCT = 10,
	NOV = 11,
	DEC = 12
}
/// <summary>
/// Handler of the whole gameplay
/// -Gailbert Huang
/// </summary>
public class GameManager : MonoBehaviour 
{
	[SerializeField] AreaMode areaMode = AreaMode.FARM;
	[SerializeField] PlayerHandler playerHandler;
	[SerializeField] PlantHandler plantHandler;
	private static GameManager instance;
	private KalachingStateMachine stateMachine;
	private int dayCounter = 1;
	private int monthCounter = 1;
	public static GameManager Instance { get { return instance; } }
	public AreaMode GetAreaMode{get { return areaMode; }}
	public KalachingStateMachine StateMachine{get{ return stateMachine;}}
	public int DayCounter
	{
		set{ dayCounter = value;}
		get{ return dayCounter;}
	}
	public int MonthCounter
	{
		set{ monthCounter = value;}
		get{ return monthCounter;}
	}
	public KalachingGameControls GameControls
	{
		get { return KalachingGameControls.Instance != null ? KalachingGameControls.Instance : null; }
	}
	public PlayerHandler PlayerHandler
	{
		get { return playerHandler;}
	}
	public PlantHandler PlantHandler
	{
		get { return plantHandler;}
	}

	public void PlayerGoToSleep()
	{
		IncrementDay ();

		if (PlantHandler != null)
			PlantHandler.DayCycle ();

		if (GameControls != null)
			GameControls.NewDay ();
		
	}

	#region Monobehavior Function
	void Awake()
	{
		instance = this;
	}

	void Start()
	{
		stateMachine = new KalachingStateMachine (this);
	}
		
	void Update()
	{
		if (stateMachine != null) 
		{
			stateMachine.Update ();
		}
		if (Input.GetKeyDown (KeyCode.Space))
			PlayerGoToSleep ();
	}

	void OnDestroy()
	{
		if (stateMachine != null)
		{
			stateMachine.Destroy ();
			stateMachine = null;
		}
		instance = null;
	}
	#endregion

	public void ExitGame()
	{
		if (StateMachine.GetCurrentState.State == KalachingStates.INGAME) 
		{
			StateMachine.SwitchState (KalachingStates.EXIT);
		}
	}

	public void IncrementDay()
	{
		dayCounter += 1;
		if (dayCounter > 8) 
		{
			monthCounter += 1;
			dayCounter = 1;
			if (monthCounter > 12)
				monthCounter = 1;
		}
	}
}
