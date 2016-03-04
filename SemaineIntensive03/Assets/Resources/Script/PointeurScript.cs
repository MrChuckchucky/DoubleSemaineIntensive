using UnityEngine;
using System.Collections;

public class PointeurScript : MonoBehaviour
{
    public GameObject totem;

    private GameObject player;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.95f, player.transform.position.z);
        transform.LookAt(totem.transform.position);
        if(totem.GetComponent<TotemScript>().isActive)
        {
            if(totem.GetComponent<TotemScript>().dysActive)
            {
                gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
            }
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.blue;
        }
	}
}
