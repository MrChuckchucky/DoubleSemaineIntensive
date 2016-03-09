using UnityEngine;
using System.Collections;

public class fadeManager : MonoBehaviour {

	// Update is called once per frame
	UnityEngine.UI.Image fade;

	void Start () {
		fade = GetComponent<UnityEngine.UI.Image>();
	}



	public void startFadeDeath(float timeGoDark) {
		float time1 = timeGoDark*0.5f; 
		float time2 = timeGoDark*0.4f; 
		StartCoroutine(fadingDeath(time1, time2));
	}


	IEnumerator  fadingDeath(float time1, float time2) {
				yield return new WaitForSeconds(time1);
			
				float wait = time2;

				Color Color1 = Color.black;
				Color1.a = 0f; 
				Color Color2 = Color.black;

				while(wait > 0f) {
					yield return null;
					fade.color = Color.Lerp(Color1, Color2, 1f - wait / time2);
					wait -= Time.deltaTime;
				}
				fade.color = Color2; 
		yield return new WaitForSeconds(0.1f);

		 wait = time2;

		while(wait > 0f) {
			yield return null;
			fade.color = Color.Lerp(Color2, Color1, 1f - wait / time2);
			wait -= Time.deltaTime;
		}
			
			
	}

	IEnumerator Fondu ()
	{
		float x = 0;
		while (x < 1)
		{
			x += 0.1f;
			fade.color = new Color (0f, 0f,0f, x);
			yield return new WaitForSeconds(0.1f);
		}
	}
}
