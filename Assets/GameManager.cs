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

    public void UpdateHealth()
    {
        UIHealth Health = DmgBar.GetComponent<UIHealth>();
        Health.PercentHealth -= 10;
        if (Health.PercentHealth <= 0)
        {
            //Game Over
            SceneManager.GetComponent<SceneFunctions>().SwitchtoGGScene();
        }
    }

    public void AddBerry()
    {
        BerryCount.GetComponent<Increment>().Count += 1;
    }

    public void AddGold()
    {
        GoldCount.GetComponent<Increment>().Count += 1;
    }

    public void AddSugar()
    {
        SugarCount.GetComponent<Increment>().Count += 1;
    }

}
