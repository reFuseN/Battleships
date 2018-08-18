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
		_isSelected = !_isSelected;
		foreach (Image img in _shipImages)
		{
			if (img.color == Color.blue)
			{
				img.color = Color.cyan;
			}
			else
			{
				img.color = Color.blue;
			}
		}
	}
}
