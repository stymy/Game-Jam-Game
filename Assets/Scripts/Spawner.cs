 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Variables 
    [SerializeField]
    private List<GameObject> m_enemyList = new List<GameObject>(); // Creates list of Game Objects

    public int score;
    [SerializeField] private int activateCounter;
    [SerializeField]
    public GameObject m_enemy;

    [SerializeField]
    private GameObject m_trigger;

    [SerializeField]
    private int m_spawnAmount = 5;

    public Transform m_location;
    public float m_spawnVariation;
    [SerializeField] private bool m_spawnTrigger;   // Spawn only if a trigger is activated.
    [SerializeField] private bool m_spawn;	// Spawn at the start.
    [SerializeField] private bool m_away;	// Spawn at the start.
    public bool m_timerSpawn;

    public float time = 5;

    // Use this for initialization
    void Start()
    {
        //score = GameObject.FindObjectsOfType<Score>()[0];
    }

    void OnTriggerEnter(Collider collision)
    {
        if (m_spawnTrigger == true)
        {
            if (collision.gameObject.tag == "Player")
            {
                //StartCoroutine(SpawnObjects());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimedSpawner();
        for (int i = 0; i < m_enemyList.Count; ++i) //If enemy list greater than 0...
        {
            if (m_enemyList[i] == null) //If enemy list is 0 it's null.
            {
                m_enemyList.RemoveAt(i); //Remove one?
                --i; // Remove another?
            }
        }
        if (m_enemyList.Count == 0) //If they're all gone...
        {
        }
        #region SCORE KILLCOUNT
        if (m_spawn == true && score >= activateCounter)
        {
            StartCoroutine(SpawnObjects());
            //SpawnObjects();
        }
        #endregion
    }

    void TimedSpawner()
    {
        if (m_timerSpawn)
        {
            StartCoroutine("SpawnTimer");
        }
    }

    IEnumerator SpawnTimer()
    {

        yield return new WaitForSeconds(30);
        Vector3 newPosition = transform.position; //Get position.

        for (int i = 0; i < m_spawnAmount; ++i)
        { // If the spawn amount is greater than 0...
            float variation = 3; //Variable for spawn range.
            float randX = Random.Range(-variation, variation); //Spawn range for X axis.
            float randZ = Random.Range(-variation, variation); //Spawn range for z axis.

            newPosition = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randZ); // Position of where the enemy will / can possibly spawn.
            GameObject enemy = Instantiate(m_enemy, newPosition, Quaternion.identity) as GameObject; //Create some clones of the enemy.
            m_enemyList.Add(enemy); // Add enemy.
                                    //Debug.Log ("Spawned an Enemy."); // Let me know an enemy is spawned.
        }
    }

    public IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(time);
        Destroy(m_trigger); //Destroy the trigger.
        Vector3 newPosition = m_location.transform.position; //Get position.

        for (int i = 0; i < m_spawnAmount; ++i)
        { // If the spawn amount is greater than 0...
            float variation = m_spawnVariation; //Variable for spawn range.
            float randX = Random.Range(-variation, variation); //Spawn range for X axis.
            float randZ = Random.Range(-variation, variation); //Spawn range for z axis.

            newPosition = new Vector3(m_location.transform.position.x + randX, m_location.transform.position.y, m_location.transform.position.z + randZ); // Position of where the enemy will / can possibly spawn.
            GameObject enemy = Instantiate(m_enemy, newPosition, Quaternion.identity) as GameObject; //Create some clones of the enemy.
            m_enemyList.Add(enemy); // Add enemy.
        }
    }
}