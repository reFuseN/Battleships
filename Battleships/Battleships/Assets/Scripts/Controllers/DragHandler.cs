using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	private CanvasGroup _thisCanvasGroup;
	public static GameObject itemBeingDragged;
	private Vector3 _startPosition;
	private Transform _startParent;

	private void Awake()
	{
		_thisCanvasGroup = GetComponent<CanvasGroup>();
		if (_thisCanvasGroup == null)
			Debug.LogError(string.Format("There is no CanvasGroup attached to {0}!", this.name));
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		itemBeingDragged = this.gameObject;
		_startPosition = this.transform.position;
		_startParent = this.transform.parent;
		_thisCanvasGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		this.transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		itemBeingDragged = null;
		_thisCanvasGroup.blocksRaycasts = true;
		if (this.transform.parent != _startParent)
		{
			this.transform.position = _startPosition;
		}
	}
}
