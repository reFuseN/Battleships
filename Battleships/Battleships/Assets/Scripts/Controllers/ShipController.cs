using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShipController : MonoBehaviour, IPointerClickHandler
{
	protected ShipSettingsModel _shipSettings;
	public ShipSettingsModel ShipSettings
	{
		set
		{
			if (_shipSettings == null)
				_shipSettings = value;
			else
				Debug.LogError("ShipSettings has already been set!");
		}
	}
	[SerializeField]
	protected bool _isSelected;
	protected Image[] _shipImages;

	protected virtual void Awake()
	{
		_shipImages = GetComponentsInChildren<Image>();
	}

	public virtual void OnPointerClick(PointerEventData eventData)
	{
		// deselect current ship that is selected, if there is one
		if (GameController.Instance.SelectedShip != null)
			GameController.Instance.SelectedShip.SelectThisShip(false);

		// select this ship
		GameController.Instance.SelectedShip = this;
		GameController.Instance.SelectedShip.SelectThisShip(true);
	}

	public void SelectThisShip(bool value)
	{
		_isSelected = value;

		foreach (Image img in _shipImages)
			img.color = (value) ? Color.cyan : Color.blue;

		GameController.Instance.SelectedShip = (value) ? this : null;
	}
}
