using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    [SerializeField] private GameObject Ammo;
    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private Transform Player;
    [SerializeField] private float speed = 1f;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Inputs();
    }

    private void Inputs()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        //if(Input.GetButton("Fire1") && Ammo.tag == "automatic")
        //{
        //    Fire();
        //}
    }

    private void Fire()
    {
        GameObject Bullet = Instantiate(Ammo, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
        Bullet.SetActive(true);

        Bullet.GetComponent<Rigidbody>().velocity = Player.transform.forward * speed;
        GetComponent<AudioSource>().Play();

        Destroy(Bullet, 10.0f);
    }
}
