using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandardShipFactory : AbstractFactory
{
	[SerializeField]
	private ShipSettingsModel _shipSettings;

	private void Awake()
	{
		Build();
	}

	public override void Build()
	{
		//initialization of building process
		base.Build();

		// bulding process
		for (int i = 0; i < _shipSettings.FieldSize; i++)
		{
			GameObject shipField = Instantiate(_gameSettings.FieldSettings.FieldPrefab, this.transform);
			shipField.GetComponent<Image>().color = Color.blue;
			shipField.GetComponent<RectTransform>().sizeDelta = GameController.Instance.SingleFieldSize;
		}
		ShipController ship = this.gameObject.AddComponent<ShipController>();
		ship.ShipSettings = _shipSettings;
		ship.Alignment = ALIGNMENT_AXIS.HORIZONTAL;
		HorizontalLayoutGroup layout = ship.gameObject.AddComponent<HorizontalLayoutGroup>();
		layout.childForceExpandHeight = false;
		layout.childForceExpandWidth = false;
		layout.childControlHeight = false;
		layout.childControlWidth = false;
	}
}
