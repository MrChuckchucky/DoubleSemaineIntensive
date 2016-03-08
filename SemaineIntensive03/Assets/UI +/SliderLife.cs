using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderLife : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Slider> ().maxValue = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ().maxLife;
		GetComponent<Slider>().value = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().life;
	}
}
