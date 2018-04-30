using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MovementTouchController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler  
{
	[SerializeField] private Image bgImg;
	private Vector3 inputVector;
	private Vector2 touchPos;

	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform
			,ped.position
			,ped.pressEventCamera
			,out pos))
		{ 
			Vector3 screenTouch = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			touchPos = new Vector2 (screenTouch.x, screenTouch.y);
		}
	}

	public virtual void OnPointerDown(PointerEventData ped) 
	{
		OnDrag(ped);
	}

	public virtual void OnPointerUp(PointerEventData ped) 
	{
		inputVector = Vector3.zero;
	}

	public Vector2 TouchPosition()
	{
		//Debug.Log (touchPos);
		return touchPos;
	}

	public Vector2 ForceSetPosition
	{
		set{ touchPos = value; }
	}

	public float Horizontal()
	{
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis("Horizontal");
	}

	public float Vertical()
	{
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis("Vertical");
	}
}
