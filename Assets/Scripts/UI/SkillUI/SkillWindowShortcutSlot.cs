using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillWindowShortcutSlot : MonoBehaviour
{
    public Sprite idleImage;
    public Sprite selectedImage;

    SkillIcon currentSkill;
    Sprite currentImage;

    float scaleRange = 0.05f;
    float scaleSpeed = 15.0f;
    float t = 0;

    bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        currentImage = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelected()
    {
        
        if (isSelected == false)
            StartCoroutine(ChangeScale());
        isSelected = true;
    }

    public void OnClicked()
    {
        isSelected = false;

        StopCoroutine(ChangeScale());
        transform.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator ChangeScale()
    {
        while (true)
        {
            t += Time.deltaTime;
            float offset = Mathf.Sin(t * scaleSpeed) * scaleRange;
            transform.localScale = new Vector3(1 + offset, 1 + offset, 1 + offset);
            yield return null;
        }
    }
}
