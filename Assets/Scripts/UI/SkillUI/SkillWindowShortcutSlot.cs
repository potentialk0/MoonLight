using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SKILLSHORTCUTSTATE
{
    IDLE, SELECTED,
}

public class SkillWindowShortcutSlot : MonoBehaviour
{
    SKILLSHORTCUTSTATE state;
    public Sprite idleImage;
    public Sprite selectedImage;

    SkillIcon currentSkill;
    Sprite currentImage;

    // Start is called before the first frame update
    void Start()
    {
        state = SKILLSHORTCUTSTATE.IDLE;
        currentImage = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessState();
    }

    void ProcessState()
    {
        switch (state)
        {
            case SKILLSHORTCUTSTATE.IDLE:
                Idle();
                break;
            case SKILLSHORTCUTSTATE.SELECTED:
                Selected();
                break;
        }
    }

    public void ChangeState(SKILLSHORTCUTSTATE s)
    {
        if (state == s) return;
        state = s;

        switch (state)
        {
            case SKILLSHORTCUTSTATE.IDLE:
                currentImage = idleImage;
                break;
            case SKILLSHORTCUTSTATE.SELECTED:
                currentImage = selectedImage;
                break;
        }
    }

    void Idle()
    {

    }

    void Selected()
    {
        ImageEffect();
    }

    void ImageEffect()
    {
        // 커졌다 작아졌다
    }
}
