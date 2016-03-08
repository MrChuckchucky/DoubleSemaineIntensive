using UnityEngine;
using System.Collections;

public class TotemManager : MonoBehaviour
{
    public int objectif;
    public float checkStart;
    public float checkDelay;
	bool isPaused;
    
    public int points;
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
		isPaused = GameObject.Find ("Managers").GetComponent<PauseManager> ().IsPaused;
		if(checkStart + checkDelay <= Time.time && isPaused == false)
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
    }
    void defeat()
    {
		Application.LoadLevel(3);
    }
}
