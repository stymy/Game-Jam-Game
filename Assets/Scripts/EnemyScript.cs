using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private GameManager GM;
    [SerializeField] private int Health = 10;
    private bool CanHit = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Collision with Player
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && CanHit)
        {
            GM.UpdateHealth(10);
            Debug.Log("Enemy Hit");
            CanHit = false;
            StartCoroutine("HitTimer");
        }
    }

    //Collision with Bullet
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bullet")
        {
            Health -= 1;
            Destroy(other.gameObject);
            if (Health <= 0)
            {
                Kill();
            }
        }
    }

    IEnumerator HitTimer()
    {
        yield return new WaitForSeconds(1);
        CanHit = true;
    }

    private void Kill()
    {
        GetComponent<AudioSource>().Play();
        transform.localScale = new Vector3(0, 0, 0);
        Destroy(gameObject, 3f);
    }
}
