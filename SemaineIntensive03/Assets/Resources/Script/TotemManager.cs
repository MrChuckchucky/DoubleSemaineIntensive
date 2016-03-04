using UnityEngine;
using System.Collections;

public class TotemManager : MonoBehaviour
{
    public int objectif;
    public float checkStart;
    public float checkDelay;

    private int points;
    private GameObject[] totems;
	// Use this for initialization
	void Start ()
    {
        checkStart = Time.time;
        points = 0;
        totems = GameObject.FindGameObjectsWithTag("Totem");
	}
	// Update is called once per frame
	void Update ()
    {
        if(checkStart + checkDelay <= Time.time)
        {
            checkStart = Time.time;
            int point = 0;
            foreach (GameObject totem in totems)
            {
                if (totem.GetComponent<TotemScript>().isActive)
                {
                    point++;
                }
            }
            if (point == 0)
            {
                defeat();
            }
            points += point;
            if (points >= objectif)
            {
                win();
            }
        }
	}

    void win()
    {
        Debug.Log("win");
    }
    void defeat()
    {
        Debug.Log("lose");
    }
}
