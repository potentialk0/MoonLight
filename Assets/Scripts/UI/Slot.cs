using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum SLOTTYPE
{
    SHORTCUT, UI,
}

public class Slot : MonoBehaviour, IDropHandler
{
    Icon icon;
    [SerializeField] protected ICONTYPE iconType;
    [SerializeField] protected SLOTTYPE slotType;
    
	private void Awake()
	{
        
	}

	public void OnDrop(PointerEventData eventData)
    {
        SetIconInPlace(eventData);
    }

    protected void SetIconInPlace(PointerEventData eventData)
	{
        Icon dragIcon = eventData.pointerDrag.GetComponent<Icon>();

        // 드래그하는 아이콘이 !null 이고 iconType이 slot의 iconType과 같으면
        if (eventData.pointerDrag != null && dragIcon.iconType == iconType)
        {
            // 드래그하는 아이콘의 anchoredPosition을 slot의 anchoredPosition으로 변경
            dragIcon.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            // 해당 아이콘을 슬롯에 저장
            icon = dragIcon;
        }
        else
        {
            // 해당 아이콘의 anchoredPosition을 이전 slot의 anchoredPosition으로 변경
            dragIcon.GetComponent<RectTransform>().anchoredPosition
                = dragIcon.previousSlot.GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
