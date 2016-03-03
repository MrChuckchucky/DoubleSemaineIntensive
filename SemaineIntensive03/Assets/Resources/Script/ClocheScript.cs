﻿using UnityEngine;
using System.Collections;

public class ClocheScript : MonoBehaviour
{
    public bool isActive;
    public GameObject totemSpotted;
    public float signalDistance;
	// Use this for initialization
	void Start ()
    {
        isActive = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isActive)
        {
            signal();
        }
	}

    void signal()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Swapable");
        foreach(GameObject enemy in enemies)
        {
            float distance = Mathf.Abs(enemy.transform.position.x - transform.position.x) + Mathf.Abs(enemy.transform.position.z - transform.position.z);
            if(distance < signalDistance)
            {
                enemy.GetComponent<EnemyScript>().totemSpotted = totemSpotted;
                enemy.GetComponent<EnemyScript>().reachtotem = true;
            }
        }
    }
}