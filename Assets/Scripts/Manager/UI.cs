using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    static GraphicRaycaster graphicRaycaster;

	private void Awake()
	{
        graphicRaycaster = GetComponent<GraphicRaycaster>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 캐릭터 조작 시 UI를 건드렸을 때 raycast가 작동하지 않게 하기 위해 UI를 건드렸는지 판별하는 함수
    public bool IsUIHit()
	{
        PointerEventData pointerEventData = new PointerEventData(null);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        if (results.Count < 1)
            return false;
        else
            return true;
	}

    public static Slot GetCurrentSlot()
	{
        PointerEventData pointerEventData = new PointerEventData(null);
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        foreach(RaycastResult result in results)
		{
            if (result.gameObject.GetComponent<Slot>() != null)
                return result.gameObject.GetComponent<Slot>();
		}

        return null;
    }
}
