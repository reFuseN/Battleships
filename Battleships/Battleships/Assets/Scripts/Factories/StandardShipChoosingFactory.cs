using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardShipChoosingFactory : AbstractFactory
{
	protected RectTransform _shipChoosingField;

	public override void Build()
	{
		//initialization of building
		base.Build();
		_shipChoosingField = GameController.Instance.ShipChoosingField;

		//building process
		foreach (ShipSettingsModel ship in GameController.Instance.GameSettings.Battleships)
		{
			Instantiate(ship.ShipObject, _shipChoosingField);
		}
	}
}
