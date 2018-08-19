using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShipPlacementFieldBehaviour : FieldBehaviour
{
	public ShipPlacementFieldBehaviour(FieldController thisField, FieldController[,] fields, uint row, uint column) : base(thisField, fields, row, column)
	{
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (GameController.Instance.SelectedShip != null)
		{
			ShipController ship = GameController.Instance.SelectedShip;
			int dimension = (ship.Alignment == ALIGNMENT_AXIS.VERTICAL) ? 0 : 1;
			uint startIndex = (ship.Alignment == ALIGNMENT_AXIS.VERTICAL) ? _row : _column;

			// if there is enough space
			if (_fields.GetLength(dimension) >= startIndex + ship.ShipSettings.FieldSize)
			{
				// go through all fields that will contain the ship and be colored
				for (uint i = startIndex; i < startIndex + ship.ShipSettings.FieldSize; i++)
				{
					if (dimension == 0)
					{
						_fields[_row, i].Image.color = Color.blue;
						_fields[_row, i].IsContainingShip = true;
					}
					else
					{
						_fields[i, _column].Image.color = Color.blue;
						_fields[i, _column].IsContainingShip = true;
					}
					Destroy(GameController.Instance.SelectedShip.gameObject);
				}
			}
			
			if (GameController.Instance.ShipChoosingField.childCount <= 1)
			{
				GameController.Instance.ShipPositionsChosen();
			}
			
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		HoverFields(true);
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		HoverFields(false);
	}

	protected void HoverFields(bool setActive)
	{
		if (GameController.Instance.SelectedShip != null)
		{
			// set local variables that will be needed for the field validation
			ShipController ship = GameController.Instance.SelectedShip;
			List<FieldController> fieldsToColor = new List<FieldController>();
			List<FieldController> fieldsToCheck = new List<FieldController>();
			int dimension =  (ship.Alignment == ALIGNMENT_AXIS.VERTICAL) ? 0 : 1;
			uint startIndex = (ship.Alignment == ALIGNMENT_AXIS.VERTICAL) ? _row : _column;
			bool isSettable = true;

			// check if there is enough space for the ship
			if (_fields.GetLength(dimension) >= startIndex + ship.ShipSettings.FieldSize)
			{
				// set fields that need to be validated
				for (uint i = startIndex; i < startIndex + ship.ShipSettings.FieldSize; i++)
				{
					if (dimension == 0)
					{
						fieldsToCheck.Add(_fields[i, _column]);
					}
					else if (dimension == 1)
					{
						fieldsToCheck.Add(_fields[_row, i]);
					}
				}

				// go through fields that need to be checked
				// if the field is not containing a ship and can be set, add it to fields that need to be colorized
				// otherwise set isSettable to false
				foreach (FieldController field in fieldsToCheck)
				{
					if (!field.IsContainingShip && isSettable)
					{
						fieldsToColor.Add(field);
					}
					else
					{
						isSettable = false;
					}
				}
			}
			// if the ship can be set into the given fields &
			// the fields should be set to active the fields will be colored like a selected ship
			// otherwise they will be colored as usual
			if (isSettable)
			{
				foreach (FieldController field in fieldsToColor)
				{
					if (setActive)
						field.Image.color = Color.cyan;
					else
						field.Image.color = Color.white;
				}
			}
		}
	}
}
