using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FieldController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	protected FieldBehaviour _behaviour;
	protected uint _row;
	public uint Row
	{
		get
		{
			return _row;
		}
		set
		{
			_row = value;
		}
	}
	protected uint _column;
	public uint Column
	{
		get
		{
			return _column;
		}
		set
		{
			_column = value;
		}
	}
	protected Image _image;
	public Image Image { get { return _image; } }

	protected bool _isContainingShip = false;
	public bool IsContainingShip
	{
		get
		{
			return _isContainingShip;
		}
		set
		{
			_isContainingShip = value;
		}
	}
	protected bool _isDead = false;
	public bool IsDead
	{
		get
		{
			return _isDead;
		}
		set
		{
			_isDead = value;
		}
	}

	private void Awake()
	{
		_image = GetComponentInChildren<Image>();
	}

	public void SetBehaviour(FieldBehaviour behaviour)
	{
		_behaviour = behaviour;
	}

	public virtual void OnPointerClick(PointerEventData eventData)
	{
		_behaviour.OnPointerClick(eventData);
	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
		_behaviour.OnPointerEnter(eventData);
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
		_behaviour.OnPointerExit(eventData);
	}
}
