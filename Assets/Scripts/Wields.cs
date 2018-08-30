using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wields : MonoBehaviour {

    public bool HasCookieGun = false;
    public bool HasPizzaBazooka = false;
    public bool HasMuffinRifle = false;
    [SerializeField] private GameObject CookieGun;
    [SerializeField] private GameObject PizzaBazooka;
    private GameObject CurrentWeapon;
	// Use this for initialization
	void Start () {
        CookieGun.SetActive(false);
        PizzaBazooka.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EquipCookieGun()
    {
        if (HasCookieGun)
        {
            if (CurrentWeapon)
            { CurrentWeapon.SetActive(false); }
            CookieGun.SetActive(true);
            CurrentWeapon = CookieGun;
        }
    }

    public void EquipPizzaBazooka()
    {
        if (HasPizzaBazooka)
        {
            if (CurrentWeapon)
            { CurrentWeapon.SetActive(false); }
            PizzaBazooka.SetActive(true);
            CurrentWeapon = PizzaBazooka;
        }
    }
}
