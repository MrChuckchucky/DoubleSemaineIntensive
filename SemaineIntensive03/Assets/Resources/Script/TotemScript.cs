using UnityEngine;
using System.Collections;

public class TotemScript : MonoBehaviour
{
    public bool isActive;
    public bool dysActive;
    public float dysactiveStart;
    public float dysactiveDelay;
    public float distance;
	// Use this for initialization
	void Start ()
    {
        dysActive = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(dysactiveStart + dysactiveDelay <= Time.time && dysActive)
        {
            dysactive();
        }
        if(!dysActive)
        {
            dysactiveStart = Time.time;
        }
        if(dysActive)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Swapable");
            bool test = true;
            foreach(GameObject enemy in enemies)
            {
                float far = Mathf.Abs(transform.position.x - enemy.transform.position.x) + Mathf.Abs(transform.position.z - enemy.transform.position.z);
                if(far < distance)
                {
                    test = false;
                    break;
                }
            }
            if(test)
            {
                //dysActive = false;
            }
        }
	}

    void dysactive()
    {
        dysActive = false;
        isActive = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Swapable");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyScript>().totemDetected = false;
            enemy.GetComponent<EnemyScript>().reachtotem = false;
        }
        GameObject cloche = GameObject.FindGameObjectWithTag("Cloche");
        cloche.GetComponent<ClocheScript>().isActive = false;
        cloche.GetComponent<ClocheScript>().totemSpotted = null;
    }
}
