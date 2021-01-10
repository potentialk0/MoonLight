using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField]
    protected GameObject obj;
    protected Image icon;
    protected int aa = 10;
    Canvas canvas;

    public GameObject a;
    public GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameObject.Find("Child").GetComponent<Test>().aa);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
		{
            //Debug.Log(a.GetComponent<Text>().text);
            //Debug.Log(b.GetComponent<Text>().text);
        }
    }
}

public class Animal : MonoBehaviour
{
    int id;
    string skillName;
    string description;
    Image icon;
    GameObject playerModel;
    GameObject playerObject;

	private void Awake()
	{
        playerModel = GameObject.Find("PlayerModel");
        playerObject = GameObject.Find("PlayerObject");
	}

	public virtual void UseSkill()
	{

	}
}

public class Dog : Animal
{
	
}

public class Cat : Animal
{

}