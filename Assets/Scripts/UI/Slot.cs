using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour, IDropHandler
{
    Icon icon;
    [SerializeField]
    ICONTYPE iconType;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        //eventData.pointerDrag
        if (eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<Icon>().iconType == iconType)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            icon = eventData.pointerDrag.GetComponent<Icon>();
        }
        else
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition
                = eventData.pointerDrag.GetComponent<Icon>().previousSlot.GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
