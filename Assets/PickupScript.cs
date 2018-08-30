using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

    [SerializeField] Transform Wielded;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //this.transform.SetPositionAndRotation(Wielded.position, Wielded.rotation);
        //this.transform.SetParent(other.transform);
        if (other.tag == "Player")
        {
            other.GetComponent<Wields>().HasCookieGun = true;
            other.GetComponent<Wields>().EquipCookieGun();
            Destroy(this.gameObject);
        }

    }
}
