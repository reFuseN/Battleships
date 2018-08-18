using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardShipChoosingFactory : AbstractFactory
{
	protected RectTransform _shipChoosingField;

	protected override void Start()
	{
		_shipChoosingField = GameController.Instance.ShipChoosingField;
		base.Start();
	}

	protected override void Build()
	{
		foreach (ShipSettingsModel ship in GameController.Instance.GameSettings.Battleships)
		{
			Instantiate(ship.ShipObject, _shipChoosingField);
		}
	}
}
