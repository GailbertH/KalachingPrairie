using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MovementTouchController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler  
{
	[SerializeField] private Image bgImg;
	private Vector3 inputVector;

	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform
			,ped.position
			,ped.pressEventCamera
			,out pos))
		{
			pos.x = (pos.x /bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y /bgImg.rectTransform.sizeDelta.y);

			inputVector = new Vector3 (pos.x * 2f, 0f, pos.y * 2f);
			inputVector = (inputVector.magnitude > 1f) ? inputVector.normalized : inputVector;
			Debug.Log (inputVector.ToString());
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
