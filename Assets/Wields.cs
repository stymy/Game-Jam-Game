using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wields : MonoBehaviour {

    public bool HasCookieGun = false;
    [SerializeField] private GameObject CookieGun;
    private GameObject CurrentWeapon;
	// Use this for initialization
	void Start () {
        CookieGun.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EquipCookieGun()
    {
        if (HasCookieGun)
        {
            CookieGun.SetActive(true);
            CurrentWeapon = CookieGun;
        }
    }
}
