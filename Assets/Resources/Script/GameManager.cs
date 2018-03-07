using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler of the whole gameplay
/// -Gailbert Huang
/// </summary>
public class GameManager : MonoBehaviour 
{
	/*
	private static GameManager instance;
	private KalachingStateMachine stateMachine;

	public static GameManager Instance { get { return instance; } }

	public KalachingStateMachine StateMachine
	{
		get { return this.stateMachine; }
	}

	public KalachingGameControls GameControls
	{
		get { return KalachingGameControls.Instance != null ? KalachingGameControls.Instance : null; }
	}

	#region Monobehavior Function
	void Awake()
	{
		instance = this;
	}

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
	#endregion
	*/
}
