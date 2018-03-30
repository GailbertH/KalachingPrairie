using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
	private static GameManager instance;
	//private KalachingStateMachine stateMachine;

	public static GameManager Instance { get { return instance; } }
	public AreaMode GetAreaMode{get { return areaMode; }}
	/*
	public KalachingStateMachine StateMachine
	{
		get { return this.stateMachine; }
	}
		*/
	public KalachingGameControls GameControls
	{
		get { return KalachingGameControls.Instance != null ? KalachingGameControls.Instance : null; }
	}

	#region Monobehavior Function
	void Awake()
	{
		instance = this;
	}
	/*
	void Start()
	{
		stateMachine = new BrynhildrStateMachine (this);
	}

	void OnDestroy()
	{
		if (stateMachine != null)
		{
			stateMachine.Destroy ();
			stateMachine = null;
		}
	}

	void Update()
	{
		if (stateMachine != null) 
		{
			stateMachine.Update ();
		}
	}
	*/
	#endregion

}
