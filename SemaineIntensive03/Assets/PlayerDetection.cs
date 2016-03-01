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

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.transform.parent.GetComponent<EnemyScript>().destination = collision.gameObject.transform.position;
        }
    }
}
