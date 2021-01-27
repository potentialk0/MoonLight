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
    [SerializeField] protected Icon _icon;
    [SerializeField] protected ICONTYPE _iconType;
    [SerializeField] protected SLOTTYPE _slotType;

    public Icon icon { get => _icon; }
    public ICONTYPE iconType { get => _iconType; }
    public SLOTTYPE slotType { get => _slotType; }

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
        if (eventData.pointerDrag != null && dragIcon.iconType == _iconType)
        {
            // 드래그하는 아이콘의 anchoredPosition을 slot의 anchoredPosition으로 변경
            //dragIcon.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            dragIcon.transform.position = transform.position;
            // 해당 아이콘을 슬롯에 저장
            _icon = dragIcon;
        }
        else
        {
            // 해당 아이콘의 anchoredPosition을 이전 slot의 anchoredPosition으로 변경
            dragIcon.transform.position = dragIcon.previousSlot.transform.position;
        }
        
    }
}
