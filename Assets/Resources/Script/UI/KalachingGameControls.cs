using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalachingGameControls : MonoBehaviour 
{
	[SerializeField] private Camera mainCamera;

	private static KalachingGameControls instance;


	public static KalachingGameControls Instance { get { return instance; } }

	void Awake()
	{
		instance = this;
		mainCamera.gameObject.SetActive (false);
	}
}
