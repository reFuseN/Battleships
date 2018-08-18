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
		SetHorizontal();
		this.gameObject.AddComponent<ShipController>().ShipSettings = _shipSettings;
	}

	private void SetVertical()
	{
		VerticalLayoutGroup layout = gameObject.AddComponent<VerticalLayoutGroup>();
		layout.childForceExpandHeight = false;
		layout.childForceExpandWidth = false;
		layout.childControlHeight = false;
		layout.childControlWidth = false;
	}

	private void SetHorizontal()
	{
		HorizontalLayoutGroup layout = gameObject.AddComponent<HorizontalLayoutGroup>();
		layout.childForceExpandHeight = false;
		layout.childForceExpandWidth = false;
		layout.childControlHeight = false;
		layout.childControlWidth = false;
	}
}
