using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public abstract class FieldBehaviour : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	protected FieldController[,] _fields;
	protected FieldController _thisField;
	protected uint _row;
	protected uint _column;

	public FieldBehaviour(FieldController thisField, FieldController[,] fields, uint row, uint column)
	{
		_thisField = thisField;
		_fields = fields;
		_row = row;
		_column = column;
	}

	public abstract void OnPointerClick(PointerEventData eventData);

	public abstract void OnPointerEnter(PointerEventData eventData);

	public abstract void OnPointerExit(PointerEventData eventData);
}
