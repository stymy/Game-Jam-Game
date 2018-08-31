using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

    [SerializeField] string WeaponType;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (WeaponType == "CookieGun")
            {
                other.GetComponent<Wields>().HasCookieGun = true;
                other.GetComponent<Wields>().EquipCookieGun();
            }

            if (WeaponType == "PizzaBazooka")
            {
                other.GetComponent<Wields>().HasPizzaBazooka = true;
                other.GetComponent<Wields>().EquipPizzaBazooka();
            }

            if (WeaponType == "MuffinRifle")
            {
                other.GetComponent<Wields>().HasMuffinRifle = true;
                other.GetComponent<Wields>().EquipMuffinRifle();
            }

            GetComponent<AudioSource>().Play();
            transform.localScale = new Vector3(0, 0, 0);
            Destroy(gameObject, 3f);
        }

    }
}
