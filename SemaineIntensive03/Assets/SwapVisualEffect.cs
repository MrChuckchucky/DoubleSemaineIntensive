using UnityEngine;
using System.Collections;

public class SwapVisualEffect : MonoBehaviour {

	const float min = 0f; 
	const float max = 3f; 

	float value = 0f;

	// Update is called once per frame
	void Update () {
		float TL = Input.GetAxis ("TriggerLeft");

		if(TL > 0) {
			value += Time.deltaTime*3.5f;
		}

		else {
			value -= Time.deltaTime*2f;
		}



		value = Mathf.Clamp(value, 0f, 1f);

		GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity = Mathf.Lerp(min, max, value);
	}
}
