using UnityEngine;
using DarkTonic.MasterAudio;
using System.Collections;

public class ClocheScript : MonoBehaviour
{
    public bool isActive;
    public GameObject totemSpotted;
    public float signalDistance;
	// Use this for initialization
	bool isPaused;
	float timerStart;
	public float timerDelay;

	void Start ()
    {
        isActive = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		isPaused = GameObject.Find ("Managers").GetComponent<PauseManager> ().IsPaused;
		if(isActive && isPaused == false)
        {
			timerStart += Time.deltaTime;
			if (timerStart >= timerDelay) 
			{
				timerStart = 0;
				isActive = false;
			}
            signal();
        }
	}

    void signal()
    {
		MasterAudio.FireCustomEvent ("BellRinging", this.transform.position);
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Swapable");
		foreach(GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(enemy.transform.position, transform.position);
			if(distance < signalDistance)
			{
				enemy.GetComponent<EnemyScript>().totemSpotted = totemSpotted;
				enemy.GetComponent<EnemyScript>().reachtotem = true;
			}
		}
    }

	public void BellSound () {
		this.GetComponent<AudioSource> ().Play ();
	}
}
