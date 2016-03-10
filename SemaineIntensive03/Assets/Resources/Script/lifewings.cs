using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class lifewings : MonoBehaviour {

	PlayerScript P;

	public List<UnityEngine.UI.Image> plumesList;

	public List<Animator> animationlifeList;


	public UnityEngine.Sprite lifeH;
	public UnityEngine.Sprite deadH;

	public UnityEngine.Sprite lifeB;
	public UnityEngine.Sprite deadB;


	public Animator anim; 
	 

	// Use this for initialization
	void Start () {
		P =  GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ();


		foreach (Animator e in animationlifeList) {
			e.gameObject.SetActive(false);
		}
	} 

	private int oldvalue = -1;

	public int decal = 0;


	float life ;
	float lifeMax ;

	// Update is called once per frame
	void Update () {
		P =  GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ();

		 life = P.life;
		 lifeMax = P.maxLife;

		if(life <= 0f)
			life = 0f;
		
		if( life == lifeMax && decal != 0){ 

			decal = 0;

			for (int i = 0; i < 8 ; i++) {
				
				if (i % 2 == 0) {
					plumesList[i].sprite = lifeH;
				}

				else {
					plumesList[i].sprite = lifeB;
				}

			} 
		} 




		int nombreDePlume = (int)((life/lifeMax)*8f); 




		if(life <= 0f)
			life = 0f;
		


		if( life == 0f) {
			plumesList[0].sprite = deadH;
		}

		else {
			plumesList[0].sprite = lifeH;
		}


		if (nombreDePlume == 8)
			nombreDePlume = 7;



		if (oldvalue == -1) {
			oldvalue = nombreDePlume;
		}

		else if(oldvalue > nombreDePlume) {
			int lostPlume = oldvalue - nombreDePlume;

			for(int i = 0 ; i < lostPlume ; i++) {
				
				animationlifeList[7 - (decal + i) ].gameObject.SetActive(true);
				if ( (7-decal+i) % 2 == 0) {
					StartCoroutine( deactivate(animationlifeList[7 - (decal + i) ].gameObject, plumesList[7 - (decal + i) ] , deadH ,animationlifeList[7 - (decal + i) ].GetCurrentAnimatorClipInfo(0)[0].clip.length *0.5f) );
				}

				else {
					StartCoroutine( deactivate(animationlifeList[7 - (decal + i) ].gameObject, plumesList[7 - (decal + i) ] , deadB ,animationlifeList[7 - (decal + i) ].GetCurrentAnimatorClipInfo(0)[0].clip.length *0.5f) );
				}
			} 

			oldvalue = nombreDePlume;

			decal += lostPlume;
		}

		else {
			oldvalue = nombreDePlume;
		}
	}

	IEnumerator deactivate(GameObject Ob, UnityEngine.UI.Image plume , UnityEngine.Sprite e  ,float time1) {
		plume.gameObject.SetActive(false);
		yield return new WaitForSeconds(time1);
		Ob.SetActive(false);
		plume.sprite = e; 
		plume.gameObject.SetActive(true);
	}


	public void reset() { 
		//P =  GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ();

		decal = 0;  

		for (int i = 0; i < 8 ; i++) {

			if (i % 2 == 0) {
				plumesList[i].sprite = lifeH;
			}

			else {
				plumesList[i].sprite = lifeB;
			}

		}

		plumesList[0].sprite = lifeH;
	}

}
