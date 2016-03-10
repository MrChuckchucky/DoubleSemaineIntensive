using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class lifewings : MonoBehaviour {

	PlayerScript P;

	public List<UnityEngine.UI.Image> plumesList;

	public UnityEngine.Sprite lifeH;
	public UnityEngine.Sprite deadH;

	public UnityEngine.Sprite lifeB;
	public UnityEngine.Sprite deadB;



	// Use this for initialization
	void Start () {
	
	}
	 
	// Update is called once per frame
	void Update () {
		P =  GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ();
		if (P) 
		{
			float life = P.life;
			float lifeMax = P.maxLife;
			
			if (life <= 0f)
				life = 0f;
			int nombreDePlume = (int)((life/lifeMax)*8f);
			
			
			if (life <= 0f)
				life = 0f;
			
			
			for (int i = 0; i < 8 ; i++) {
				if ( i  < nombreDePlume ) {
					if (i % 2 == 0) {
						plumesList[i].sprite = lifeH;
					}
					
					else {
						plumesList[i].sprite = lifeB;
					}
				}
				else {
					if (i % 2 == 0) {
						plumesList[i].sprite = deadH;
					}
					
					else {
						plumesList[i].sprite = deadB;
					}
				}
			}
		}

	}
}
