using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShipPlacementFieldBehaviour : FieldBehaviour
{
	public override void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("CLICK");
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("ENTER");
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("EXIT");
	}
}
