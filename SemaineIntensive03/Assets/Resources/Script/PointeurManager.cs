using UnityEngine;
using System.Collections;

public class PointeurManager : MonoBehaviour
{
    public GameObject pointeur;

    public GameObject[] totems;
    private GameObject player;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        totems = GameObject.FindGameObjectsWithTag("Totem");
        foreach(GameObject totem in totems)
        {
            GameObject ptr = Instantiate(pointeur, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1.5f), transform.rotation) as GameObject;
            ptr.GetComponent<PointeurScript>().totem = totem;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
}
