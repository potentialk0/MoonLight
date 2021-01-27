using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum ICONTYPE
{
	ITEM, SKILL,
}

public class Icon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
	protected Canvas canvas;
	protected RectTransform rectTransform;
	protected CanvasGroup canvasGroup;

	//Slot _previousSlot;

	public Slot currentSlot { get; protected set; }
	public Slot previousSlot { get; protected set; }// => _previousSlot; protected set => _previousSlot = value; }

	public ICONTYPE iconType { get; protected set; }

	private void Awake()
	{
		rectTransform	= GetComponent<RectTransform>();
		canvas			= GameObject.Find("Canvas").GetComponent<Canvas>();
		canvasGroup		= GetComponent<CanvasGroup>();
	}

	public virtual void OnPointerDown(PointerEventData eventData)
	{
		canvasGroup.alpha = 0.8f;
		if (eventData != null)
		{
			previousSlot = UI.GetCurrentSlot();
			transform.SetAsLastSibling();
		}
	}

	public virtual void OnBeginDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		canvasGroup.alpha = 1.0f;
	}

	public virtual void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;
		if (UI.GetCurrentSlot() == null)
		{
			transform.position = previousSlot.transform.position;
			
		}
		else
		{
			currentSlot = UI.GetCurrentSlot();
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		SwitchIcon(eventData);
	}

	protected void SwitchIcon(PointerEventData eventData)
	{
		Icon dragIcon = eventData.pointerDrag.GetComponent<Icon>();
		if (eventData.pointerDrag != null && dragIcon.iconType == iconType)
		{
			dragIcon.transform.position = transform.position;
			transform.position = dragIcon.previousSlot.transform.position;
			//dragIcon.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
			//GetComponent<RectTransform>().anchoredPosition
			//	= dragIcon.previousSlot.GetComponent<RectTransform>().anchoredPosition;
		}
		else
		{
			dragIcon.transform.position = dragIcon.previousSlot.transform.position;
		}
	}
}
