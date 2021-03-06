﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] public GameManager GM;
    [SerializeField] public GameObject Target;
    [SerializeField] private int Health = 10;
    private bool CanHit = true;
    UnityEngine.AI.NavMeshAgent nav;

    // Use this for initialization
    void Start()
    {
    }

    private void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }
    // Update is called once per frame
    void Update()
    {
        nav.destination = Target.transform.position;
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

    //On Collision with Pizza Mine
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mine")
        {
            Kill();
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
