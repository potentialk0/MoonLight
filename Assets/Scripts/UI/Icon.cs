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
	Slot currentSlot;

	public Slot previousSlot { get; protected set; }

	public ICONTYPE iconType { get; protected set; }

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public virtual void OnPointerDown(PointerEventData eventData)
	{
		canvasGroup.alpha = 0.8f;
		if (eventData != null)
		{
			previousSlot = canvas.GetComponent<UI>().GetCurrentSkillSlot();
			transform.SetAsLastSibling();
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
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

	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;
		if(canvas.GetComponent<UI>().GetCurrentSkillSlot() == null)
		{
			GetComponent<RectTransform>().anchoredPosition = previousSlot.GetComponent<RectTransform>().anchoredPosition;
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Icon>().iconType == iconType)
		{
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
			GetComponent<RectTransform>().anchoredPosition
				= eventData.pointerDrag.GetComponent<Icon>().previousSlot.GetComponent<RectTransform>().anchoredPosition;
		}
		else
		{
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition
				= eventData.pointerDrag.GetComponent<Icon>().previousSlot.GetComponent<RectTransform>().anchoredPosition;
		}
	}
}
