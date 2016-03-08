using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] NavigationPoint;
    public bool randomPatrol;
    public int ID;
	// Use this for initialization
	void Start ()
    {
        GetComponent<Renderer>().material.color = Color.red;
	}
	
	// Update is called once per frame
	public void Spawn ()
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
	}
}
