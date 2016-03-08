using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderVictoire : MonoBehaviour 
{
    private TotemManager scriptTotem;

	// Use this for initialization
	void Start () 
    {
        scriptTotem = GameObject.FindObjectOfType<TotemManager>();

        GetComponent<Slider>().maxValue = scriptTotem.objectif;
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<Slider>().value = scriptTotem.points;
	}
}
