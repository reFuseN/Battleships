using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ALIGNMENT_AXIS
{
	HORIZONTAL,
	VERTICAL
}

public class ShipController : MonoBehaviour, IPointerClickHandler
{
	protected ShipSettingsModel _shipSettings;
	public ShipSettingsModel ShipSettings
	{
		get
		{
			return _shipSettings;
		}
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
	protected ALIGNMENT_AXIS _alignment;
	public ALIGNMENT_AXIS Alignment
	{
		get
		{
			return _alignment;
		}
		set
		{
			_alignment = value;
		}
	}

	protected virtual void Awake()
	{
		_shipImages = GetComponentsInChildren<Image>();
	}

	// if this ship is currently not selected, deselect old selection and select this one, otherwise deselect this one
	public virtual void OnPointerClick(PointerEventData eventData)
	{
		if (_isSelected && GameController.Instance.SelectedShip == this)
		{
			GameController.Instance.SelectedShip.SelectThisShip(false);
		}
		else
		{
			// deselect current ship that is selected, if there is one
			if (GameController.Instance.SelectedShip != null)
				GameController.Instance.SelectedShip.SelectThisShip(false);

			// select this ship
			GameController.Instance.SelectedShip = this;
			GameController.Instance.SelectedShip.SelectThisShip(true);
		}
	}

	public virtual void SelectThisShip(bool value)
	{
		_isSelected = value;

		foreach (Image img in _shipImages)
			img.color = (value) ? Color.cyan : Color.blue;

		GameController.Instance.SelectedShip = (value) ? this : null;
	}
}
