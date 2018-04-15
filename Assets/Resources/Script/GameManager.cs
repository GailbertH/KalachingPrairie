using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kalaching.Game;

public enum AreaMode
{
	FARM = 0,
	TOWN = 1
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

	public static GameManager Instance { get { return instance; } }
	public AreaMode GetAreaMode{get { return areaMode; }}
	public KalachingStateMachine StateMachine{get{ return stateMachine;}}

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
}
