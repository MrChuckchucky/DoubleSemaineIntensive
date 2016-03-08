using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public float spawnStart;
    public float spawnDelay;
	bool isPaused;
    public int MaxEnemy1;
    public int MaxEnemy2;
    public int MaxEnemy3;
    
    private GameObject[] spawners;
    private int index;
    private int[] ID;
    void Start()
    {
        index = 0;
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        ID = new int[spawners.Length + 1];
    }

	// Update is called once per frame
	void Update ()
    {
		isPaused = GameObject.Find ("Managers").GetComponent<PauseManager> ().IsPaused;
		if(isPaused == false)
        {
            spawnStart += Time.deltaTime;
            if (spawnStart <= spawnDelay)
            {
                spawnStart = 0;
                int min = 0, index = 0;
                for (int i = 0; i < ID.Length; i++)
                {
                    ID[i] = 0;
                }
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Swapable");
                if (this.GetComponentInParent<TotemManager>().points >= this.GetComponentInParent<TotemManager>().objectif / 3)
                {
                    if (this.GetComponentInParent<TotemManager>().points >= this.GetComponentInParent<TotemManager>().objectif / 3 * 2)
                    {
                        if (enemies.Length < MaxEnemy3)
                        {
                            foreach (GameObject enemy in enemies)
                            {
                                ID[enemy.GetComponent<EnemyScript>().ID] += 1;
                            }
                            for (int i = 0; i < ID.Length; i++)
                            {
                                if (i == 0)
                                {
                                    min = ID[i];
                                    index = i;
                                }
                                if (ID[i] < min)
                                {
                                    min = ID[i];
                                    index = i;
                                }
                            }
                            Spawn(index);
                        }
                    }
                    else
                    {
                        if (enemies.Length < MaxEnemy2)
                        {
                            foreach (GameObject enemy in enemies)
                            {
                                ID[enemy.GetComponent<EnemyScript>().ID] += 1;
                            }
                            for (int i = 0; i < ID.Length; i++)
                            {
                                if (i == 0)
                                {
                                    min = ID[i];
                                    index = i;
                                }
                                if (ID[i] < min)
                                {
                                    min = ID[i];
                                    index = i;
                                }
                            }
                            Spawn(index);
                        }
                    }
                }
                else
                {
                    if (enemies.Length < MaxEnemy1)
                    {
                        foreach (GameObject enemy in enemies)
                        {
                            ID[enemy.GetComponent<EnemyScript>().ID] += 1;
                        }
                        for (int i = 0; i < ID.Length; i++)
                        {
                            if (i == 0)
                            {
                                min = ID[i];
                                index = i;
                            }
                            if (ID[i] < min)
                            {
                                min = ID[i];
                                index = i;
                            }
                        }
                        Spawn(index);
                    }
                }
            }
        }
    }
    void Spawn(int ID)
    {
        foreach(GameObject spawner in spawners)
        {
            if(spawner.GetComponent<SpawnScript>().ID == ID)
            {
                spawner.GetComponent<SpawnScript>().Spawn();
            }
        }
    }
}
