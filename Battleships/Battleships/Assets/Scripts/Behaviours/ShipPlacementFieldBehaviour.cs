using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShipPlacementFieldBehaviour : FieldBehaviour
{
	public ShipPlacementFieldBehaviour(FieldController thisField, FieldController[,] fields, uint row, uint column) : base(thisField, fields, row, column)
	{
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("CLICK");
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		if (GameController.Instance.SelectedShip != null)
		{
			uint row = _thisField.Row;
			uint column = _thisField.Column;
			_fields[row, column].GetComponent<Image>().color = Color.cyan;
			/*
			int thisIndex = System.Array.IndexOf(_fields, _thisField);
			int shipSize = GameController.Instance.SelectedShip.ShipSettings.FieldSize;
			for (int i = thisIndex; thisIndex < thisIndex + shipSize; i++)
			{
				_fields[i].GetComponent<Image>().color = Color.cyan;
			}
			*/

		}
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		if (GameController.Instance.SelectedShip != null)
		{
			/*
			int thisIndex = System.Array.IndexOf(_fields, _thisField);
			int shipSize = GameController.Instance.SelectedShip.ShipSettings.FieldSize;
			for (int i = thisIndex; thisIndex < thisIndex + shipSize; i++)
			{
				_fields[i].GetComponent<Image>().color = Color.white;
			}
			*/
		}
	}
}
