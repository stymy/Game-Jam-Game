using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    [SerializeField] private GameManager GM;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Collision with Player
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider);
        if (collision.collider.tag == "Player")
        {
            Debug.Log("hello");
            GM.UpdateHealth(10);
        }
    }
}
