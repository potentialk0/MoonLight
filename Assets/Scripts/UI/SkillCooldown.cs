using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    protected string abilityInputName = "";
    protected Image darkMask;
    protected Text cooldownText;

    [SerializeField] private Skill skill;
    [SerializeField] private GameObject playerModel;
    private Image image;
    private AudioSource abilityAudio;
    private float cooldownDuration;
    private float nextReadyTime;
    private float cooldownTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        Initialize(skill, playerModel);
    }

    // Update is called once per frame
    void Update()
    {
        bool cooldownComplete = (Time.time > nextReadyTime);
        if (cooldownComplete)
		{
            AbilityReady();
            if(Input.GetKeyDown(abilityInputName))
			{
                ButtonTriggered();
			}
		}
        else
        {
            CoolDown();
        }
    }

    public void Initialize(Skill ability, GameObject playerModel)
	{
        this.skill = ability;
        this.playerModel = playerModel;
        image = GetComponent<Image>();
        //image.sprite = ability.sprite;
        abilityAudio = GetComponent<AudioSource>();
        //cooldownDuration = ability.basecooldown
        //ability.Initialize(playerModel);
        AbilityReady();
	}

    private void AbilityReady()
	{
        cooldownText.enabled = false;
        darkMask.enabled = false;
	}

    private void CoolDown()
	{
        cooldownTimeLeft -= Time.deltaTime;
        float roundedCooldown = Mathf.Round(cooldownTimeLeft);
        cooldownText.text = roundedCooldown.ToString();
        darkMask.fillAmount = (cooldownTimeLeft / cooldownDuration);
	}

    private void ButtonTriggered()
	{
        nextReadyTime = cooldownDuration + Time.time;
        cooldownTimeLeft = cooldownDuration;
        cooldownText.enabled = true;
        darkMask.enabled = true;

        //abilityAudio.clip = ability.sound;
        //abilityAudio.Play();
        skill.UseSkill();
	}
}
