using UnityEngine;
using System.Collections;

public class invocationBar : MonoBehaviour {

	public UnityEngine.UI.Image bar; 
	public UnityEngine.UI.Text Text;

	private TotemManager scriptTotem;
	private float maxValue;

	private bool part1 = false;
	private bool part2 = false;


	// Use this for initialization
	void Start () {
		scriptTotem = GameObject.FindObjectOfType<TotemManager>();
		maxValue = scriptTotem.objectif;
		Text.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		bar.fillAmount =  scriptTotem.points/maxValue;
	
		if (!part1 && bar.fillAmount >= 0.333f) {
			part1 = true;
			StartCoroutine(showText());
		}

		else if (!part2 && bar.fillAmount >= 0.666f) {
			part2 = true;
			StartCoroutine(showText());
		}
	}

	IEnumerator showText() {
		Text.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		Text.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f);

		Text.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		Text.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f); 


		Text.gameObject.SetActive(true);
		yield return new WaitForSeconds(2.0f);
		Text.gameObject.SetActive(false);


	}
}
