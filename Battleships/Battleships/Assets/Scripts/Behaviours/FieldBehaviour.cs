using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public abstract class FieldBehaviour : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	public abstract void OnPointerClick(PointerEventData eventData);

	public abstract void OnPointerEnter(PointerEventData eventData);

	public abstract void OnPointerExit(PointerEventData eventData);
}
