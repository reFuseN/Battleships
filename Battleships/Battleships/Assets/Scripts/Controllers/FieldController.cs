using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

	public void SetBehaviour(FieldBehaviour behaviour)
	{
		_behaviour = behaviour;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		_behaviour.OnPointerClick(eventData);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_behaviour.OnPointerEnter(eventData);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_behaviour.OnPointerExit(eventData);
	}
}
