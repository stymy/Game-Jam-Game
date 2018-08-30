using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour {
    private Vector3 m_MoveDirection;

    // Use this for initialization
    void Start () {
        StartCoroutine("Life");
        Move();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Life()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }

    private void Move()
    {
        this.GetComponent<Rigidbody>().velocity.Set(1,0,0);

    }
}
