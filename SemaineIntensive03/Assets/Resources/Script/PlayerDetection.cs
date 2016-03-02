using UnityEngine;
using System.Collections;

public class PlayerDetection : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.transform.parent.GetComponent<EnemyScript>().Player = collision.gameObject;
            gameObject.transform.parent.GetComponent<EnemyScript>().playerDetected = true;
        }
    }
    void OnTriggerExit()
    {
        gameObject.transform.parent.GetComponent<EnemyScript>().playerDetected = false;
    }
}
