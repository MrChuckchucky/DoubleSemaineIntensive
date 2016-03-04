using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public bool isActiveted;
    public float spawnStart;
    public float spawnDelay;

    private GameObject[] spawners;
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

	// Update is called once per frame
	void Update ()
    {
        if(isActiveted)
        {
            if(spawnStart + spawnDelay <= Time.time)
            {
                foreach(GameObject spawner in spawners)
                {
                    spawner.GetComponent<SpawnScript>().isActive = true;
                    spawner.GetComponent<SpawnScript>().spawnStart = Time.time;
                }
            }
        }
	}
}
