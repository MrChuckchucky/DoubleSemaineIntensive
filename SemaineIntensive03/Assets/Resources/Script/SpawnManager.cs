using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public bool isActiveted;
    public float spawnStart;
    public float spawnDelay;
	bool isPaused;
    private GameObject[] spawners;
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

	// Update is called once per frame
	void Update ()
    {
		isPaused = GameObject.Find ("Managers").GetComponent<PauseManager> ().IsPaused;
		if(isActiveted && isPaused == false)
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
