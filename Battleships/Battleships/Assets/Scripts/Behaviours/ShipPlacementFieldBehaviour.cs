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
			int row = (int)_thisField.Row;
			int column = (int)_thisField.Column;
			

			// if ship is horizontal, check for enough space in columns
			if (ship.Alignment == ALIGNMENT_AXIS.HORIZONTAL)
			{
				// if there is enough space
				if (_fields.GetLength(1) >= column + ship.ShipSettings.FieldSize)
				{
					for (int i = column; i < column + ship.ShipSettings.FieldSize; i++)
					{
						_fields[row, i].Image.color = Color.blue;
						_fields[row, i].IsContainingShip = true;
						Destroy(GameController.Instance.SelectedShip.gameObject);
					}
				}
			}
			// if ship is vertical, check for enough space in rows
			if (ship.Alignment == ALIGNMENT_AXIS.VERTICAL)
			{
				// if there is enough space
				if (_fields.GetLength(0) >= row + ship.ShipSettings.FieldSize)
				{
					for (int i = row; i < row + ship.ShipSettings.FieldSize; i++)
					{
						_fields[i, column].Image.color = Color.blue;
						_fields[i, column].IsContainingShip = true;
						Destroy(GameController.Instance.SelectedShip.gameObject);
					}
				}
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
			ShipController ship = GameController.Instance.SelectedShip;
			int row = (int)_thisField.Row;
			int column = (int)_thisField.Column;
			bool isSettable = false;
			List<FieldController> fieldsToColor = new List<FieldController>();

			// if ship is horizontal, check for enough space in columns
			if (ship.Alignment == ALIGNMENT_AXIS.HORIZONTAL)
			{
				// if there is enough space & field is not already containing ship
				if (_fields.GetLength(1) >= column + ship.ShipSettings.FieldSize)
				{
					for (int i = column; i < column + ship.ShipSettings.FieldSize; i++)
					{
						if (!_fields[row, i].IsContainingShip && !isSettable)
						{
							fieldsToColor.Add(_fields[row, i]);
						}
						else
							isSettable = true;
					}
				}
			}
			// if ship is vertical, check for enough space in rows
			if (ship.Alignment == ALIGNMENT_AXIS.VERTICAL)
			{
				// if there is enough space & fields are not containing a ship
				if (_fields.GetLength(0) >= row + ship.ShipSettings.FieldSize)
				{
					for (int i = row; i < row + ship.ShipSettings.FieldSize; i++)
					{
						if (!_fields[i, column].IsContainingShip && !isSettable)
						{
							fieldsToColor.Add(_fields[i, column]);
						}
						else
							isSettable = true;
					}
				}
			}

			if (!isSettable)
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
