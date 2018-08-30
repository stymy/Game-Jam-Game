using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject DmgBar;
    public GameObject BerryCount;
    public GameObject GoldCount;
    public GameObject SugarCount;

    public GameObject SceneManager;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateHealth(int Dmg)
    {
        //Updates Player Health Functions
        UIHealth Health = DmgBar.GetComponent<UIHealth>();
        Health.Damage(Dmg);
        if (Health.PercentHealth <= 0)
        {
            //Game Over
            SceneManager.GetComponent<SceneFunctions>().SwitchtoGGScene();
        }
    }

    public void AddBerry()
    {
        //Increments Currency
        BerryCount.GetComponent<Increment>().Count += 1;
        Debug.Log("hello");
    }

    public void AddGold()
    {
        //Increments Currency
        GoldCount.GetComponent<Increment>().Count += 1;
    }

    public void AddSugar()
    {
        //Increments Currency
        SugarCount.GetComponent<Increment>().Count += 1;
    }

}
