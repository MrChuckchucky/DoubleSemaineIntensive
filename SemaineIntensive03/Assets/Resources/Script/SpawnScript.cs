using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    public float spawnStart;
    public float spawnDelay;
    public GameObject enemy;
    public GameObject[] NavigationPoint;
    public bool randomPatrol;
    public int ID;
    public bool isActive;
	bool isPaused;
	// Use this for initialization
	void Start ()
    {
        GetComponent<Renderer>().material.color = Color.red;
        isActive = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		isPaused = GameObject.Find ("Managers").GetComponent<PauseManager> ().IsPaused;
		if(spawnStart + spawnDelay <= Time.time && isActive && isPaused == false)
        {
            GameObject Enemy = Instantiate(enemy, transform.position, transform.rotation) as GameObject;
            Enemy.GetComponent<EnemyScript>().ID = ID;
            Enemy.GetComponent<EnemyScript>().NavigationPoints = NavigationPoint;
            Enemy.GetComponent<EnemyScript>().patrouilleRandom = randomPatrol;
            int rand = Random.Range(1, 4);
            switch(rand)
            {
                case 1:
                    Enemy.GetComponent<EnemyScript>().EType = EnemyManager.EnemyType.HEAVY;
                    break;
                case 2:
                    Enemy.GetComponent<EnemyScript>().EType = EnemyManager.EnemyType.SNEAKY;
                    break;
                case 3:
                    Enemy.GetComponent<EnemyScript>().EType = EnemyManager.EnemyType.SNIPER;
                    break;
            }
            isActive = false;
        }
	}
}
